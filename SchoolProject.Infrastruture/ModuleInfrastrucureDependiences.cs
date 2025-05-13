using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Entites.Veiws;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Abstract.Functions;
using SchoolProject.Infrastruture.Abstract.IViews;
using SchoolProject.Infrastruture.Abstract.Procudure;
using SchoolProject.Infrastruture.Repositiries;
using SchoolProject.Infrastruture.Repositiries.Functions;
using SchoolProject.Infrastruture.Repositiries.Procudure;

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
            services.AddScoped<IRefreshTokenRepositiry, RefreshTokenRepositiry>();


            // Veiws 
            services.AddScoped<IViewsRepositiry<VeiwDepartment>, ViewDepartmentRepositiry>();

            // sTORED PROCUDURE

            services.AddScoped<IDepartmentStudentCountProcRepositiry, DepartmentStudentCountProcRepositiry>();


            // Function 
            services.AddScoped<IInsttactorFunctionRepositiry, InstractorFunctionRepositiry>();



            return services;

        }
    }
}
