using LSCode.Files.FTP.Interfaces;
using LSCode.Files.FTP.Services;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace LSCode.Files.Test.Integration.FTP.Services
{
    internal class FTPServiceTest
    {
        private readonly static string binFtpTestFile = @$"{AppDomain.CurrentDomain.BaseDirectory}\testFile.txt";
        private readonly static string ftpTestDirectory = "ftp://192.168.56.1/ftpTestDirectory";
        private readonly static string ftpTestFile = "ftp://192.168.56.1/testFile.txt";

        private readonly IFTPService _fTPService;

        public FTPServiceTest() => _fTPService = new FTPService("lscode.ftp", "root");

        [SetUp]
        public void SetUp()
        {
            if (File.Exists(binFtpTestFile))
                File.Delete(binFtpTestFile);

            if (_fTPService.DirectoryExists(ftpTestDirectory))
                _fTPService.DeleteDirectory(ftpTestDirectory);

            if (_fTPService.FileExists(ftpTestFile))
                _fTPService.DeleteFile(ftpTestFile);
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(binFtpTestFile))
                File.Delete(binFtpTestFile);

            if (_fTPService.DirectoryExists(ftpTestDirectory))
                _fTPService.DeleteDirectory(ftpTestDirectory);

            if (_fTPService.FileExists(ftpTestFile))
                _fTPService.DeleteFile(ftpTestFile);
        }

        [Test]
        public void AppendFile_FromBase64String_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            var fileBase64StringAppend = "IGFwcGVuZGVk";

            //Act
            _fTPService.AppendFile(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(13));
            });
        }

        [Test]
        public void AppendFile_FromBase64String_FileDoesNotExist()
        {
            //Arrange
            var fileBase64StringAppend = "IGFwcGVuZGVk";

            //Act
            _fTPService.AppendFile(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(9));
            });
        }

        [Test]
        public void AppendFile_FromBytes_FileExists()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            _fTPService.UploadFile(fileBytes, ftpTestFile);

            var fileBytesAppend = Convert.FromBase64String("IGFwcGVuZGVk");

            //Act
            _fTPService.AppendFile(ftpTestFile, fileBytesAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(13));
            });
        }

        [Test]
        public void AppendFile_FromBytes_FileDoesNotExist()
        {
            //Arrange
            var fileBytesAppend = Convert.FromBase64String("IGFwcGVuZGVk");

            //Act
            _fTPService.AppendFile(ftpTestFile, fileBytesAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(9));
            });
        }

        [Test]
        public async Task AppendFileAsync_FromBase64String_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            var fileBase64StringAppend = "IGFwcGVuZGVk";

            //Act
            await _fTPService.AppendFileAsync(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(13));
            });
        }

        [Test]
        public async Task AppendFileAsync_FromBase64String_FileDoesNotExist()
        {
            //Arrange
            var fileBase64StringAppend = "IGFwcGVuZGVk";

            //Act
            await _fTPService.AppendFileAsync(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(9));
            });
        }

        [Test]
        public async Task AppendFileAsync_FromBytes_FileExists()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            _fTPService.UploadFile(fileBytes, ftpTestFile);

            var fileBytesAppend = Convert.FromBase64String("IGFwcGVuZGVk");

            //Act
            await _fTPService.AppendFileAsync(ftpTestFile, fileBytesAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(13));
            });
        }

        [Test]
        public async Task AppendFileAsync_FromBytes_FileDoesNotExist()
        {
            //Arrange
            var fileBytesAppend = Convert.FromBase64String("IGFwcGVuZGVk");

            //Act
            await _fTPService.AppendFileAsync(ftpTestFile, fileBytesAppend);

            var exist = _fTPService.FileExists(ftpTestFile);
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(size, Is.EqualTo(9));
            });
        }

        [Test]
        public void CreateDirectory()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            //Act
            var exist = _fTPService.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task CreateDirectoryAsync()
        {
            //Arrange
            await _fTPService.CreateDirectoryAsync(ftpTestDirectory);

            //Act
            var exist = _fTPService.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DeleteDirectory_DirectoryExists()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            //Act
            _fTPService.DeleteDirectory(ftpTestDirectory);

            var exist = _fTPService.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteDirectory_DirectoryDoesNotExist()
        {
            //Assert
            Assert.Throws<WebException>(() => _fTPService.DeleteDirectory(ftpTestDirectory));
        }

        [Test]
        public async Task DeleteDirectoryAsync_DirectoryExists()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            //Act
            await _fTPService.DeleteDirectoryAsync(ftpTestDirectory);

            var exist = _fTPService.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteDirectoryAsync_DirectoryDoesNotExist()
        {
            //Assert
            Assert.ThrowsAsync<WebException>(() => _fTPService.DeleteDirectoryAsync(ftpTestDirectory));
        }

        [Test]
        public void DeleteFile_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            _fTPService.DeleteFile(ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DeleteFile_FileDoesNotExist()
        {
            //Act
            _fTPService.DeleteFile(ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteFileAsync_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            await _fTPService.DeleteFileAsync(ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DeleteFileAsync_FileDoesNotExist()
        {
            //Act
            await _fTPService.DeleteFileAsync(ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DirectoryExists_DirectoryExists()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            //Act
            var exist = _fTPService.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DirectoryExists_DirectoryDoesNotExist()
        {
            //Act
            var exist = _fTPService.DirectoryExists(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task DirectoryExistsAsync_DirectoryExists()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            //Act
            var exist = await _fTPService.DirectoryExistsAsync(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task DirectoryExistsAsync_DirectoryDoesNotExist()
        {
            //Act
            var exist = await _fTPService.DirectoryExistsAsync(ftpTestDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void DownloadFile_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            _fTPService.DownloadFile(ftpTestFile, binFtpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DownloadFile_FileDoesNotExist()
        {
            //Assert
            Assert.Throws<WebException>(() => _fTPService.DownloadFile(ftpTestFile, binFtpTestFile));
        }

        [Test]
        public async Task DownloadFileAsync_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            await _fTPService.DownloadFileAsync(ftpTestFile, binFtpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void DownloadFileAsync_FileDoesNotExist()
        {
            //Assert
            Assert.ThrowsAsync<WebException>(() => _fTPService.DownloadFileAsync(ftpTestFile, binFtpTestFile));
        }

        [Test]
        public void FileExists_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void FileExists_FileDoesNotExist()
        {
            //Act
            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task FileExistsAsync_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var exist = await _fTPService.FileExistsAsync(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task FileExistsAsync_FileDoesNotExist()
        {
            //Act
            var exist = await _fTPService.FileExistsAsync(ftpTestFile);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void GetFileSize_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.That(size, Is.EqualTo(4));
        }

        [Test]
        public void GetFileSize_FileDoesNotExist()
        {
            //Act
            var size = _fTPService.GetFileSize(ftpTestFile);

            //Assert
            Assert.That(size, Is.Zero);
        }

        [Test]
        public async Task GetFileSizeAsync_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var size = await _fTPService.GetFileSizeAsync(ftpTestFile);

            //Assert
            Assert.That(size, Is.EqualTo(4));
        }

        [Test]
        public async Task GetFileSizeAsync_FileDoesNotExist()
        {
            //Act
            var size = await _fTPService.GetFileSizeAsync(ftpTestFile);

            //Assert
            Assert.That(size, Is.Zero);
        }

        [Test]
        public void GetLastModifiedDateUTC_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var date = _fTPService.GetLastModifiedDateUTC(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(date.Date, Is.EqualTo(DateTime.UtcNow.Date));
                Assert.That(date.Hour, Is.EqualTo(DateTime.UtcNow.Hour));
                Assert.That(date.Minute, Is.EqualTo(DateTime.UtcNow.Minute));
            });
        }

        [Test]
        public void GetLastModifiedDateUTC_FileDoesNotExist()
        {
            //Assert
            Assert.Throws<WebException>(() => _fTPService.GetLastModifiedDateUTC(ftpTestFile));
        }

        [Test]
        public async Task GetLastModifiedDateUTCAsync_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var date = await _fTPService.GetLastModifiedDateUTCAsync(ftpTestFile);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(date.Date, Is.EqualTo(DateTime.UtcNow.Date));
                Assert.That(date.Hour, Is.EqualTo(DateTime.UtcNow.Hour));
                Assert.That(date.Minute, Is.EqualTo(DateTime.UtcNow.Minute));
            });
        }

        [Test]
        public void GetLastModifiedDateUTCAsync_FileDoesNotExist()
        {
            //Assert
            Assert.ThrowsAsync<WebException>(() => _fTPService.GetLastModifiedDateUTCAsync(ftpTestFile));
        }

        [Test]
        public void ListDirectoryContent_ListOfFilesAndDirectories()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);
            _fTPService.CreateDirectory($@"{ftpTestDirectory}\dir1");
            _fTPService.CreateDirectory($@"{ftpTestDirectory}\dir2");
            _fTPService.CreateDirectory($@"{ftpTestDirectory}\dir3");
            _fTPService.UploadFile("dGVzdA==", $@"{ftpTestDirectory}\testFile.txt");

            //Act
            var list = _fTPService.ListDirectoryContent(ftpTestDirectory);

            _fTPService.DeleteDirectory($@"{ftpTestDirectory}\dir1");
            _fTPService.DeleteDirectory($@"{ftpTestDirectory}\dir2");
            _fTPService.DeleteDirectory($@"{ftpTestDirectory}\dir3");
            _fTPService.DeleteFile($@"{ftpTestDirectory}\testFile.txt");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list[0], Is.EqualTo("ftpTestDirectory/dir1"));
                Assert.That(list[1], Is.EqualTo("ftpTestDirectory/dir2"));
                Assert.That(list[2], Is.EqualTo("ftpTestDirectory/dir3"));
                Assert.That(list[3], Is.EqualTo("ftpTestDirectory/testFile.txt"));
            });
        }

        [Test]
        public void ListDirectoryContent_WithoutContent()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            //Act
            var list = _fTPService.ListDirectoryContent(ftpTestDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list, Is.Empty);
            });
        }

        [Test]
        public async Task ListDirectoryContentAsync_ListOfFilesAndDirectories()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);
            _fTPService.CreateDirectory($@"{ftpTestDirectory}\dir1");
            _fTPService.CreateDirectory($@"{ftpTestDirectory}\dir2");
            _fTPService.CreateDirectory($@"{ftpTestDirectory}\dir3");
            _fTPService.UploadFile("dGVzdA==", $@"{ftpTestDirectory}\testFile.txt");

            //Act
            var list = await _fTPService.ListDirectoryContentAsync(ftpTestDirectory);

            _fTPService.DeleteDirectory($@"{ftpTestDirectory}\dir1");
            _fTPService.DeleteDirectory($@"{ftpTestDirectory}\dir2");
            _fTPService.DeleteDirectory($@"{ftpTestDirectory}\dir3");
            _fTPService.DeleteFile($@"{ftpTestDirectory}\testFile.txt");

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list[0], Is.EqualTo("ftpTestDirectory/dir1"));
                Assert.That(list[1], Is.EqualTo("ftpTestDirectory/dir2"));
                Assert.That(list[2], Is.EqualTo("ftpTestDirectory/dir3"));
                Assert.That(list[3], Is.EqualTo("ftpTestDirectory/testFile.txt"));
            });
        }

        [Test]
        public async Task ListDirectoryContentAsync_WithoutContent()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            //Act
            var list = await _fTPService.ListDirectoryContentAsync(ftpTestDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list, Is.Empty);
            });
        }

        [Test]
        public void Rename_DirectoryExists()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            var newPath = "ftp://192.168.56.1/directoryRenamed";

            //Act
            _fTPService.Rename(ftpTestDirectory, "directoryRenamed");

            var exist = _fTPService.DirectoryExists(newPath);

            _fTPService.DeleteDirectory(newPath);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void Rename_DirectoryDoesNotExist()
        {
            //Assert
            Assert.Throws<WebException>(() => _fTPService.Rename(ftpTestDirectory, "directoryRenamed"));
        }

        [Test]
        public void Rename_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            var newPath = "ftp://192.168.56.1/testFileRenamed.txt";

            //Act
            _fTPService.Rename(ftpTestFile, "testFileRenamed.txt");

            var exist = _fTPService.FileExists(newPath);

            _fTPService.DeleteFile(newPath);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void Rename_FileDoesNotExist()
        {
            //Assert
            Assert.Throws<WebException>(() => _fTPService.Rename(ftpTestFile, "testFileRenamed.txt"));
        }

        [Test]
        public async Task RenameAsync_DirectoryExists()
        {
            //Arrange
            _fTPService.CreateDirectory(ftpTestDirectory);

            var newPath = "ftp://192.168.56.1/directoryRenamed";

            //Act
            await _fTPService.RenameAsync(ftpTestDirectory, "directoryRenamed");

            var exist = _fTPService.DirectoryExists(newPath);

            _fTPService.DeleteDirectory(newPath);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void RenameAsync_DirectoryDoesNotExist()
        {
            //Assert
            Assert.ThrowsAsync<WebException>(() => _fTPService.RenameAsync(ftpTestDirectory, "directoryRenamed"));
        }

        [Test]
        public async Task RenameAsync_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            var newPath = "ftp://192.168.56.1/testFileRenamed.txt";

            //Act
            await _fTPService.RenameAsync(ftpTestFile, "testFileRenamed.txt");

            var exist = _fTPService.FileExists(newPath);

            _fTPService.DeleteFile(newPath);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void RenameAsync_FileDoesNotExist()
        {
            //Assert
            Assert.ThrowsAsync<WebException>(() => _fTPService.RenameAsync(ftpTestFile, "testFileRenamed.txt"));
        }

        [Test]
        public void UploadFile_FromBase64String()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            //Act
            _fTPService.UploadFile(fileBase64String, ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void UploadFile_FromBytes()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            //Act
            _fTPService.UploadFile(fileBytes, ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task UploadFileAsync_FromBase64String()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            //Act
            await _fTPService.UploadFileAsync(fileBase64String, ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task UploadFileAsync_FromBytes()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            //Act
            await _fTPService.UploadFileAsync(fileBytes, ftpTestFile);

            var exist = _fTPService.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }
    }
}