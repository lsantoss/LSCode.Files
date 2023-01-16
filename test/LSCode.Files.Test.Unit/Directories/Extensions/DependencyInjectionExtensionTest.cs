using LSCode.Files.Directories.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LSCode.Files.Test.Unit.Directories.Extensions
{
    internal class DependencyInjectionExtensionTest
    {
        [Test]
        public void AddDirectoryService_Valid()
        {
            var services = new ServiceCollection();

            services.AddDirectoryService();

            var count = services.Count;
            var serviceType = services[0].ServiceType.Name;

            Assert.Multiple(() =>
            {
                Assert.That(count, Is.EqualTo(1));
                Assert.That(serviceType, Is.EqualTo("IDirectoryService"));
            });
        }
    }
}