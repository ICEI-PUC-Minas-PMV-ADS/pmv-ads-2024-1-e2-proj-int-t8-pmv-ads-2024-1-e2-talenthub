using Microsoft.EntityFrameworkCore;
using TalentHub.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.Google;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var keyVaultName = "puctalenthub";
var keyVaultUri = $"https://{keyVaultName}.vault.azure.net/";
builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication--Google--ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication--Google--ClientSecret"];
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var dbPassword = builder.Configuration["ConnectionStrings--DefaultConnection--Password"];

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
