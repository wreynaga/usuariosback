using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Usuarios.Application.Interface.UseCases;
using Usuarios.Application.UseCases.Users;
using Usuarios.Application.UseCases.Usuarios;
using Usuarios.Application.Validator;

namespace Usuarios.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUsersApplication, UsersApplication>();
            services.AddScoped<IUsuariosApplication, UsuariosApplication>();
            services.AddTransient<UsersDtoValidator>();
            services.AddTransient<UsuariosDtoValidator>();
            return services;
        }
    }
}
