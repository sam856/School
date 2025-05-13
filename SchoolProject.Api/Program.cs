
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.MiddelWare;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastruture;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.DataSeeder;
using SchoolProject.Services;
using Serilog;
using System.Globalization;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"))


        );
        Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

        builder.Services.AddSerilog();

        #region Dependency Injection
        builder.Services.AddInfrastrucureDependiences()
            .AddServicesBuilder()
        .AddCoreDependenices()
        .AddServicesRegestration(builder.Configuration);

        #endregion


        #region AllowCORS
        var CORS = "_cors";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: CORS,
                              policy =>
                              {
                                  policy.AllowAnyHeader();
                                  policy.AllowAnyMethod();
                                  policy.AllowAnyOrigin();
                              });
        });

        #endregion


        #region  localization
        builder.Services.AddControllersWithViews();
        builder.Services.AddLocalization(opt =>
        {
            opt.ResourcesPath = "";
        });
        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };

            options.DefaultRequestCulture = new RequestCulture("en-US");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
        #endregion

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var userManger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
            await RoleSeeder.SeedingUser(roleManager);
            await UserSeeder.SeedingUser(userManger);
        }
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        #region Localization Middleware

        var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);
        #endregion


        app.UseMiddleware<ErrorHandlerMiddleware>();

        app.UseHttpsRedirection();
        app.UseCors(CORS);
        app.UseStaticFiles();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}


