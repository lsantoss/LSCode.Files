using LSCode.Files.Files.Interfaces;
using LSCode.Files.Files.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LSCode.Files.Files.Extensions
{
    public static class DependencyInjectionExtension
    {
        /// <summary>Extension to use the implementation methods that help the manipulation of files.</summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        public static IServiceCollection AddFileService(this IServiceCollection services)
        {
            services.AddScoped<IFileService, FileHelper>();

            return services;
        }
    }
}