using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using TalentHub.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddDistributedMemoryCache();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.HttpOnly = HttpOnlyPolicy.Always;
    options.Secure = CookieSecurePolicy.Always;
});

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.None;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(GoogleDefaults.AuthenticationScheme, googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var dbPassword = builder.Configuration["ConnectionStrings:DefaultConnection:Password"];

if (!string.IsNullOrEmpty(dbPassword))
{
    var builderConn = new SqlConnectionStringBuilder(connectionString)
    {
        Password = dbPassword
    };
    connectionString = builderConn.ConnectionString;
}

builder.Services.AddDbContext<TalentHubContext>(options =>
    options.UseSqlServer(connectionString));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddHttpClient<GitHubService>((serviceProvider, client) =>
{
    var gitHubToken = builder.Configuration["GitHub:Token"];

    if (string.IsNullOrEmpty(gitHubToken))
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError("Token GitHub não configurado.");
        throw new InvalidOperationException("Token GitHub não configurado.");
    }

    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", gitHubToken);
    client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");
});

builder.Services.AddScoped<GitHubService>(serviceProvider =>
{
    var httpClient = serviceProvider.GetRequiredService<HttpClient>();
    var gitHubToken = builder.Configuration["GitHub:Token"];

    if (gitHubToken == null)
    {
        throw new InvalidOperationException("Token GitHub não configurado.");
    }

    return new GitHubService(httpClient, gitHubToken);
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
