using LSCode.Files.Files.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace LSCode.Files.Test.Unit.Files.Extensions
{
    internal class DependencyInjectionExtensionTest
    {
        [Test]
        public void AddFileService_Valid()
        {
            var services = new ServiceCollection();

            services.AddFileService();

            var count = services.Count;
            var serviceType = services[0].ServiceType.Name;

            Assert.Multiple(() =>
            {
                Assert.That(count, Is.EqualTo(1));
                Assert.That(serviceType, Is.EqualTo("IFileService"));
            });
        }
    }
}