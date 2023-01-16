using LSCode.Files.FTP.Constants;
using LSCode.Files.FTP.Interfaces;
using LSCode.Files.FTP.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LSCode.Files.FTP.Extensions
{
    public static class DependencyInjectionExtension
    {
        /// <summary>Extension to use the implementation of FTP connections, providing methods that help the manipulation of directories and files.</summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <param name="user">User used for the connection.</param>
        /// <param name="password">Password used for the connection.</param>
        public static IServiceCollection AddFTPService(this IServiceCollection services, string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException(Errors.UserNullEmptyOrWhiteSpace);

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException(Errors.PasswordNullEmptyOrWhiteSpace);

            services.AddScoped<IFTPService, FTPService>(setup => new FTPService(user, password));

            return services;
        }
    }
}