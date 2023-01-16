using LSCode.Files.FTP.Extensions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace LSCode.Files.Test.Unit.FTP.Extensions
{
    internal class DependencyInjectionExtensionTest
    {
        [Test]
        [TestCase("user1", "password1")]
        [TestCase("user2", "password2")]
        [TestCase("user3", "password3")]
        public void AddFTPService_Valid(string user, string password)
        {
            var services = new ServiceCollection();

            services.AddFTPService(user, password);

            var count = services.Count;
            var serviceType = services[0].ServiceType.Name;

            Assert.Multiple(() =>
            {
                Assert.That(count, Is.EqualTo(1));
                Assert.That(serviceType, Is.EqualTo("IFTPService"));
            });
        }

        [Test]
        [TestCase(null, "password1")]
        [TestCase("", "password2")]
        [TestCase(" ", "password3")]
        public void AddFTPService_User_Invalid(string user, string password)
        {
            var services = new ServiceCollection();

            Assert.Throws<ArgumentException>(() => services.AddFTPService(user, password));
        }

        [Test]
        [TestCase("user1", null)]
        [TestCase("user2", "")]
        [TestCase("user3", " ")]
        public void AddFTPService_Password_Invalid(string user, string password)
        {
            var services = new ServiceCollection();

            Assert.Throws<ArgumentException>(() => services.AddFTPService(user, password));
        }
    }
}
