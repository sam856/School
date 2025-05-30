﻿using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastruture.InfrastrutureBases;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.Abstract.AuthServices;
using SchoolProject.Services.Implementatios;
using SchoolProject.Services.Implementatios.AuthServices;

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
            services.AddTransient<IEmailServices, EmailServices>();
            services.AddTransient<IAuthorizationServices, AuzorizationServices>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<ICurrentUserServices, CurrentUserServices>();
            services.AddTransient<IInstractorServices, InstractorServices>();
            services.AddTransient<IFileServices, FileServices>();








            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;

        }
    }
}