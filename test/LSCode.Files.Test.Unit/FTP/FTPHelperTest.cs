using LSCode.Files.FTP;
using LSCode.Files.FTP.Interfaces;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace LSCode.Files.Test.Unit.FTP
{
    internal class FTPHelperTest
    {
        private readonly static string binFtpTestDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\ftpTestDirectory";
        private readonly static string binFtpTestFile = @$"{AppDomain.CurrentDomain.BaseDirectory}\ftpTestDirectory\testFile.txt";
        private readonly static string ftpTestDirectory = "ftp://192.168.56.1/myTestDirectory";
        private readonly static string ftpTestFile = "ftp://192.168.56.1/testFile.txt";

        private readonly IFTPHelper _fTPHelper;

        public FTPHelperTest() => _fTPHelper = new FTPHelper("lscode.ftp", "root");

        [SetUp]
        public void SetUp()
        {
            if (Directory.Exists(binFtpTestDirectory))
                Directory.Delete(binFtpTestDirectory, true);

            Directory.CreateDirectory(binFtpTestDirectory);
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            if (_fTPHelper.DirectoryExists(ftpTestDirectory))
                _fTPHelper.DeleteDirectory(ftpTestDirectory);

            _fTPHelper.CreateDirectory(ftpTestDirectory);

            if (_fTPHelper.FileExists(ftpTestFile))
                _fTPHelper.DeleteFile(ftpTestFile);

            _fTPHelper.UploadFile(binFtpTestFile, ftpTestFile);
        }

        [Test]
        public void CreateDirectory()
        {
            var newDirectory = @$"{ftpTestDirectory}/newDirectory";

            _fTPHelper.CreateDirectory(newDirectory);

            var exist = _fTPHelper.DirectoryExists(newDirectory);

            _fTPHelper.DeleteDirectory(newDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            var newDirectory = @$"{ftpTestDirectory}/newDirectory";

            await _fTPHelper.CreateDirectoryAsync(newDirectory);

            var exist = _fTPHelper.DirectoryExists(newDirectory);

            _fTPHelper.DeleteDirectory(newDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void DeleteDirectory_DirectoryExists()
        {
            _fTPHelper.DeleteDirectory(ftpTestDirectory);

            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteDirectory_DirectoryDoesNotExist()
        {
            _fTPHelper.DeleteDirectory(ftpTestDirectory);

            Assert.Throws<WebException>(() => _fTPHelper.DeleteDirectory(ftpTestDirectory));
        }

        [Test]
        public async Task DeleteDirectoryAsync_DirectoryExists()
        {
            await _fTPHelper.DeleteDirectoryAsync(ftpTestDirectory);

            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteDirectoryAsync_DirectoryDoesNotExist()
        {
            await _fTPHelper.DeleteDirectoryAsync(ftpTestDirectory);

            Assert.ThrowsAsync<WebException>(() => _fTPHelper.DeleteDirectoryAsync(ftpTestDirectory));
        }

        [Test]
        public void DeleteFile_FileExists()
        {
            _fTPHelper.DeleteFile(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteFile_FileDoesNotExist()
        {
            _fTPHelper.DeleteFile(ftpTestFile);

            _fTPHelper.DeleteFile(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteFileAsync_FileExists()
        {
            await _fTPHelper.DeleteFileAsync(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteFileAsync_FileDoesNotExist()
        {
            _fTPHelper.DeleteFile(ftpTestFile);

            await _fTPHelper.DeleteFileAsync(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void DirectoryExists_DirectoryExists()
        {
            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void DirectoryExists_DirectoryDoesNotExist()
        {
            _fTPHelper.DeleteDirectory(ftpTestDirectory);

            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DirectoryExistsAsync_DirectoryExists()
        {
            var exist = await _fTPHelper.DirectoryExistsAsync(ftpTestDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task DirectoryExistsAsync_DirectoryDoesNotExist()
        {
            _fTPHelper.DeleteDirectory(ftpTestDirectory);

            var exist = await _fTPHelper.DirectoryExistsAsync(ftpTestDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void FileExists_FileExists()
        {
            var exist = _fTPHelper.FileExists(ftpTestFile);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void FileExists_FileDoesNotExist()
        {
            _fTPHelper.DeleteFile(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task FileExistsAsync_FileExists()
        {
            var exist = await _fTPHelper.FileExistsAsync(ftpTestFile);

            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task FileExistsAsync_FileDoesNotExist()
        {
            _fTPHelper.DeleteFile(ftpTestFile);

            var exist = await _fTPHelper.FileExistsAsync(ftpTestFile);

            Assert.That(exist, Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(binFtpTestDirectory, true);

            if (_fTPHelper.DirectoryExists(ftpTestDirectory))
                _fTPHelper.DeleteDirectory(ftpTestDirectory);

            if (_fTPHelper.FileExists(ftpTestFile))
                _fTPHelper.DeleteFile(ftpTestFile);
        }
    }
}