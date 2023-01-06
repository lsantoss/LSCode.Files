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
        private readonly static string binFtpTestFile = @$"{AppDomain.CurrentDomain.BaseDirectory}\testFile.txt";
        private readonly static string ftpTestDirectory = "ftp://192.168.56.1/ftpTestDirectory";
        private readonly static string ftpTestFile = "ftp://192.168.56.1/testFile.txt";

        private readonly IFTPHelper _fTPHelper;

        public FTPHelperTest() => _fTPHelper = new FTPHelper("lscode.ftp", "root");

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(binFtpTestFile))
                File.Delete(binFtpTestFile);

            if (_fTPHelper.DirectoryExists(ftpTestDirectory))
                _fTPHelper.DeleteDirectory(ftpTestDirectory);

            if (_fTPHelper.FileExists(ftpTestFile))
                _fTPHelper.DeleteFile(ftpTestFile);
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(binFtpTestFile))
                File.Delete(binFtpTestFile);

            if (_fTPHelper.DirectoryExists(ftpTestDirectory))
                _fTPHelper.DeleteDirectory(ftpTestDirectory);

            if (_fTPHelper.FileExists(ftpTestFile))
                _fTPHelper.DeleteFile(ftpTestFile);
        }

        [Test]
        public void CreateDirectory()
        {
            //Arrange
            _fTPHelper.CreateDirectory(ftpTestDirectory);

            //Act
            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            //Arrange
            await _fTPHelper.CreateDirectoryAsync(ftpTestDirectory);

            //Act
            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DeleteDirectory_DirectoryExists()
        {
            //Arrange
            _fTPHelper.CreateDirectory(ftpTestDirectory);

            //Act
            _fTPHelper.DeleteDirectory(ftpTestDirectory);

            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteDirectory_DirectoryDoesNotExist()
        {
            //Assert
            Assert.Throws<WebException>(() => _fTPHelper.DeleteDirectory(ftpTestDirectory));
        }

        [Test]
        public async Task DeleteDirectoryAsync_DirectoryExists()
        {
            //Arrange
            _fTPHelper.CreateDirectory(ftpTestDirectory);

            //Act
            await _fTPHelper.DeleteDirectoryAsync(ftpTestDirectory);

            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteDirectoryAsync_DirectoryDoesNotExist()
        {
            //Assert
            Assert.ThrowsAsync<WebException>(() => _fTPHelper.DeleteDirectoryAsync(ftpTestDirectory));
        }

        [Test]
        public void DeleteFile_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            //Act
            _fTPHelper.DeleteFile(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteFile_FileDoesNotExist()
        {
            //Act
            _fTPHelper.DeleteFile(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteFileAsync_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            //Act
            await _fTPHelper.DeleteFileAsync(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteFileAsync_FileDoesNotExist()
        {
            //Act
            await _fTPHelper.DeleteFileAsync(ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DirectoryExists_DirectoryExists()
        {
            //Arrange
            _fTPHelper.CreateDirectory(ftpTestDirectory);

            //Act
            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DirectoryExists_DirectoryDoesNotExist()
        {
            //Act
            var exist = _fTPHelper.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DirectoryExistsAsync_DirectoryExists()
        {
            //Arrange
            _fTPHelper.CreateDirectory(ftpTestDirectory);

            //Act
            var exist = await _fTPHelper.DirectoryExistsAsync(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task DirectoryExistsAsync_DirectoryDoesNotExist()
        {
            //Act
            var exist = await _fTPHelper.DirectoryExistsAsync(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void FileExists_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            //Act
            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void FileExists_FileDoesNotExist()
        {
            //Act
            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task FileExistsAsync_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            //Act
            var exist = await _fTPHelper.FileExistsAsync(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task FileExistsAsync_FileDoesNotExist()
        {
            //Act
            var exist = await _fTPHelper.FileExistsAsync(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }
    }
}