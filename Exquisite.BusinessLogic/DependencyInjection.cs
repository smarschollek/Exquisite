using System;
using System.IO;
using LiteDB;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Exquisite.BusinessLogic.Helper.PasswordEncryption;

namespace Exquisite.BusinessLogic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordEncryptor, Sha512PasswordEncryptor>();
            services.AddTransient<ILiteDatabase>(options => new LiteDatabase(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage.db")));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
