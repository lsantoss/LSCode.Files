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
        public void DownloadFile_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            File.Delete(binFtpTestFile);

            //Act
            _fTPHelper.DownloadFile(ftpTestFile, binFtpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DownloadFile_FileDoesNotExist()
        {
            //Assert
            Assert.Throws<WebException>(() => _fTPHelper.DownloadFile(ftpTestFile, binFtpTestFile));
        }

        [Test]
        public async Task DownloadFileAsync_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            File.Delete(binFtpTestFile);

            //Act
            await _fTPHelper.DownloadFileAsync(ftpTestFile, binFtpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DownloadFileAsync_FileDoesNotExist()
        {
            //Assert
            Assert.ThrowsAsync<WebException>(() => _fTPHelper.DownloadFileAsync(ftpTestFile, binFtpTestFile));
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

        [Test]
        public void GetFileSize_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            //Act
            var size = _fTPHelper.GetFileSize(ftpTestFile);

            //Assert
            Assert.That(size, Is.EqualTo(4));
        }

        [Test]
        public void GetFileSize_FileDoesNotExist()
        {
            //Act
            var size = _fTPHelper.GetFileSize(ftpTestFile);

            //Assert
            Assert.That(size, Is.Zero);
        }

        [Test]
        public async Task GetFileSizeAsync_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            //Act
            var size = await _fTPHelper.GetFileSizeAsync(ftpTestFile);

            //Assert
            Assert.That(size, Is.EqualTo(4));
        }

        [Test]
        public async Task GetFileSizeAsync_FileDoesNotExist()
        {
            //Act
            var size = await _fTPHelper.GetFileSizeAsync(ftpTestFile);

            //Assert
            Assert.That(size, Is.Zero);
        }

        [Test]
        public void UploadFileFromBase64String()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            //Act
            _fTPHelper.UploadFileFromBase64String(fileBase64String, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task UploadFileFromBase64StringAsync()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            //Act
            await _fTPHelper.UploadFileFromBase64StringAsync(fileBase64String, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void UploadFileFromBytes()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            //Act
            _fTPHelper.UploadFileFromBytes(fileBytes, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task UploadFileFromBytesAsync()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            //Act
            await _fTPHelper.UploadFileFromBytesAsync(fileBytes, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void UploadFileFromPath()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            //Act
            _fTPHelper.UploadFileFromPath(binFtpTestFile, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task UploadFileFromPathAsync()
        {
            //Arrange
            using var streamWriter = new StreamWriter(binFtpTestFile);
            streamWriter.Write("test");
            streamWriter.Close();

            //Act
            await _fTPHelper.UploadFileFromPathAsync(binFtpTestFile, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }
    }
}