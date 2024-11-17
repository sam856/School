using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Repositiries;

namespace SchoolProject.Infrastruture
{
    public static class ModuleInfrastrucureDependiences
    {
        public static IServiceCollection AddInfrastrucureDependiences(

            this IServiceCollection services)
        {

            services.AddScoped<IStudentRepositiers, StudentRepositiry>();
            services.AddScoped<IDepartmentRepositiry, DepartmentRepositiry>();
            services.AddScoped<IInstractorRepositiry, InstractorRepositiry>();
            services.AddScoped<ISubjectRepositiry, SubjectRepositiry>();




            return services;

        }
    }
}
