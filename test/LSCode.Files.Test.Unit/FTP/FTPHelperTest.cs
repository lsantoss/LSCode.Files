﻿using LSCode.Files.FTP;
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
        public void AppendFile_FromBase64String_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

            var fileBase64StringAppend = "IGFwcGVuZGVk";

            //Act
            _fTPHelper.AppendFile(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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
            _fTPHelper.AppendFile(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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

            _fTPHelper.UploadFile(fileBytes, ftpTestFile);

            var fileBytesAppend = Convert.FromBase64String("IGFwcGVuZGVk");

            //Act
            _fTPHelper.AppendFile(ftpTestFile, fileBytesAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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
            _fTPHelper.AppendFile(ftpTestFile, fileBytesAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

            var fileBase64StringAppend = "IGFwcGVuZGVk";

            //Act
            await _fTPHelper.AppendFileAsync(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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
            await _fTPHelper.AppendFileAsync(ftpTestFile, fileBase64StringAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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

            _fTPHelper.UploadFile(fileBytes, ftpTestFile);

            var fileBytesAppend = Convert.FromBase64String("IGFwcGVuZGVk");

            //Act
            await _fTPHelper.AppendFileAsync(ftpTestFile, fileBytesAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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
            await _fTPHelper.AppendFileAsync(ftpTestFile, fileBytesAppend);

            var exist = _fTPHelper.FileExists(ftpTestFile);
            var size = _fTPHelper.GetFileSize(ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

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
        public void GetLastModifiedDateUTC_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var date = _fTPHelper.GetLastModifiedDateUTC(ftpTestFile);

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
            Assert.Throws<WebException>(() => _fTPHelper.GetLastModifiedDateUTC(ftpTestFile));
        }

        [Test]
        public async Task GetLastModifiedDateUTCAsync_FileExists()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

            //Act
            var date = await _fTPHelper.GetLastModifiedDateUTCAsync(ftpTestFile);

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
            Assert.ThrowsAsync<WebException>(() => _fTPHelper.GetLastModifiedDateUTCAsync(ftpTestFile));
        }

        [Test]
        public void ListDirectoryContent_ListOfFilesAndDirectories()
        {
            //Arrange
            _fTPHelper.CreateDirectory(ftpTestDirectory);
            _fTPHelper.CreateDirectory($@"{ftpTestDirectory}\dir1");
            _fTPHelper.CreateDirectory($@"{ftpTestDirectory}\dir2");
            _fTPHelper.CreateDirectory($@"{ftpTestDirectory}\dir3");
            _fTPHelper.UploadFile("dGVzdA==", $@"{ftpTestDirectory}\testFile.txt");

            //Act
            var list = _fTPHelper.ListDirectoryContent(ftpTestDirectory);

            _fTPHelper.DeleteDirectory($@"{ftpTestDirectory}\dir1");
            _fTPHelper.DeleteDirectory($@"{ftpTestDirectory}\dir2");
            _fTPHelper.DeleteDirectory($@"{ftpTestDirectory}\dir3");
            _fTPHelper.DeleteFile($@"{ftpTestDirectory}\testFile.txt");

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
            _fTPHelper.CreateDirectory(ftpTestDirectory);

            //Act
            var list = _fTPHelper.ListDirectoryContent(ftpTestDirectory);

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
            _fTPHelper.CreateDirectory(ftpTestDirectory);
            _fTPHelper.CreateDirectory($@"{ftpTestDirectory}\dir1");
            _fTPHelper.CreateDirectory($@"{ftpTestDirectory}\dir2");
            _fTPHelper.CreateDirectory($@"{ftpTestDirectory}\dir3");
            _fTPHelper.UploadFile("dGVzdA==", $@"{ftpTestDirectory}\testFile.txt");

            //Act
            var list = await _fTPHelper.ListDirectoryContentAsync(ftpTestDirectory);

            _fTPHelper.DeleteDirectory($@"{ftpTestDirectory}\dir1");
            _fTPHelper.DeleteDirectory($@"{ftpTestDirectory}\dir2");
            _fTPHelper.DeleteDirectory($@"{ftpTestDirectory}\dir3");
            _fTPHelper.DeleteFile($@"{ftpTestDirectory}\testFile.txt");

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
            _fTPHelper.CreateDirectory(ftpTestDirectory);

            //Act
            var list = await _fTPHelper.ListDirectoryContentAsync(ftpTestDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list, Is.Empty);
            });
        }

        [Test]
        public void UploadFile_FromBase64String()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            //Act
            _fTPHelper.UploadFile(fileBase64String, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void UploadFile_FromBytes()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            //Act
            _fTPHelper.UploadFile(fileBytes, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task UploadFileAsync_FromBase64String()
        {
            //Arrange
            var fileBase64String = "dGVzdA==";

            //Act
            await _fTPHelper.UploadFileAsync(fileBase64String, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public async Task UploadFileAsync_FromBytes()
        {
            //Arrange
            var fileBytes = Convert.FromBase64String("dGVzdA==");

            //Act
            await _fTPHelper.UploadFileAsync(fileBytes, ftpTestFile);

            var exist = _fTPHelper.FileExists(ftpTestFile);

            //Assert
            Assert.That(exist, Is.True);
        }
    }
}