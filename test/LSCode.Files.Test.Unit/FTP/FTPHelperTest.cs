using LSCode.Files.FTP;
using LSCode.Files.FTP.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace LSCode.Files.Test.Unit.FTP
{
    internal class FTPHelperTest
    {
        private readonly static string testDirectory = "ftp://192.168.100.3/myTestDirectory";

        private readonly IFTPHelper _fTPHelper;

        public FTPHelperTest() => _fTPHelper = new FTPHelper("lscode.ftp", "root");

        [SetUp]
        public void SetUp()
        {
            if (_fTPHelper.DirectoryExists(testDirectory))
                _fTPHelper.DeleteDirectory(testDirectory);

            _fTPHelper.CreateDirectory(testDirectory);
        }

        [Test]
        public void CreateDirectory()
        {
            var newDirectory = @$"{testDirectory}/newDirectory";

            _fTPHelper.CreateDirectory(newDirectory);

            var exist = _fTPHelper.DirectoryExists(newDirectory);

            _fTPHelper.DeleteDirectory(newDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            var newDirectory = @$"{testDirectory}/newDirectory";

            await _fTPHelper.CreateDirectoryAsync(newDirectory);

            var exist = _fTPHelper.DirectoryExists(newDirectory);

            _fTPHelper.DeleteDirectory(newDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void DeleteDirectory()
        {
            _fTPHelper.DeleteDirectory(testDirectory);

            var exist = _fTPHelper.DirectoryExists(testDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteDirectoryAsync()
        {
            await _fTPHelper.DeleteDirectoryAsync(testDirectory);

            var exist = _fTPHelper.DirectoryExists(testDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void DirectoryExists()
        {
            var exist = _fTPHelper.DirectoryExists(testDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task DirectoryExistsAsync()
        {
            var exist = await _fTPHelper.DirectoryExistsAsync(testDirectory);

            Assert.That(exist, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            if (_fTPHelper.DirectoryExists(testDirectory))
                _fTPHelper.DeleteDirectory(testDirectory);
        }
    }
}