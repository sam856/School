using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastruture.InfrastrutureBases;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.Implementatios;

namespace SchoolProject.Services
{
    public static class ModuleServicesBuilder
    {

        public static IServiceCollection AddServicesBuilder(

           this IServiceCollection services)
        {

            services.AddTransient<IStudentServies, StduentServices>();
            services.AddTransient<IDepartmentServies, DepartmentServices>();
            services.AddTransient<IAuthenticationServices, AuthenticationServices>();
            services.AddTransient<IAuthorizationServices, AuzorizationServices>();



            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;

        }
    }
}