using Microsoft.EntityFrameworkCore;
using TalentHub.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                     .AddEnvironmentVariables()
                     .AddUserSecrets<Program>();

builder.Services.AddControllersWithViews();

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

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
