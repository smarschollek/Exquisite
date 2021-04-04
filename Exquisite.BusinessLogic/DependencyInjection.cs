using Exquisite.BusinessLogic.Helper.StringEncryption;
using LiteDB;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Exquisite.BusinessLogic
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPasswordEncrypter, SHA512PasswordEncrypter>();
            services.AddTransient<ILiteDatabase>(options => new LiteDatabase("storage.db"));
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
