using LSCode.Files.Constants;
using LSCode.Files.Directories;
using LSCode.Files.Directories.Interfaces;
using LSCode.Files.Files;
using LSCode.Files.Files.Interfaces;
using LSCode.Files.FTP;
using LSCode.Files.FTP.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LSCode.Files.Extensions
{
    public static class DependencyInjectionExtension
    {
        /// <summary>Extension to use the implementation methods that help the manipulation of directories.</summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static IServiceCollection AddDirectoryHelper(this IServiceCollection services)
        {
            services.AddScoped<IDirectoryHelper, DirectoryHelper>();

            return services;
        }

        /// <summary>Extension to use the implementation methods that help the manipulation of files.</summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static IServiceCollection AddFTPHelper(this IServiceCollection services)
        {
            services.AddScoped<IFileHelper, FileHelper>();

            return services;
        }

        /// <summary>Extension to use the implementation of FTP connections, providing methods that help the manipulation of directories and files.</summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        /// <param name="user">User used for the connection.</param>
        /// <param name="password">Password used for the connection.</param>
        public static IServiceCollection AddFTPHelper(this IServiceCollection services, string user, string password)
        {
            if (string.IsNullOrWhiteSpace(user))
                throw new ArgumentException(Errors.UserNullEmptyOrWhiteSpace);

            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException(Errors.PasswordNullEmptyOrWhiteSpace);

            services.AddScoped<IFTPHelper, FTPHelper>(setup => new FTPHelper(user, password));

            return services;
        }
    }
}