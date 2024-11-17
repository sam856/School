
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.MiddelWare;
using SchoolProject.Infrastruture;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Services;
using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(option =>
        option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"))


        );



        #region Dependency Injection
        builder.Services.AddInfrastrucureDependiences()
            .AddServicesBuilder()
        .AddCoreDependenices();

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

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();



        app.UseMiddleware<ErrorHandlerMiddleware>();
        #region Localization Middleware

        var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(options.Value);
        #endregion




        app.MapControllers();

        app.Run();
    }
}


