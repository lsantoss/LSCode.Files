using LSCode.Files.Directories.Interfaces;
using LSCode.Files.Directories.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LSCode.Files.Directories.Extensions
{
    public static class DependencyInjectionExtension
    {
        /// <summary>Extension to use the implementation methods that help the manipulation of directories.</summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static IServiceCollection AddDirectoryService(this IServiceCollection services)
        {
            services.AddScoped<IDirectoryService, DirectoryService>();

            return services;
        }
    }
}