using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviour;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependenices
    {

        public static IServiceCollection AddCoreDependenices(

          this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg
            .RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;

        }
    }
}
