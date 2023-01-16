using LSCode.Files.Directories;
using LSCode.Files.Directories.Interfaces;
using NUnit.Framework;
using System;
using System.IO;

namespace LSCode.Files.Test.Unit.Directories
{
    internal class DirectoryHelperTest
    {
        private readonly static string testDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\myTestDirectory";
        private readonly static string testMovedDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\myMovedTestDirectory";

        private readonly IDirectoryHelper _directoryHelper;

        public DirectoryHelperTest() => _directoryHelper = new DirectoryHelper();

        [SetUp]
        public void SetUp()
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);

            if (Directory.Exists(testMovedDirectory))
                Directory.Delete(testMovedDirectory, true);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);

            if (Directory.Exists(testMovedDirectory))
                Directory.Delete(testMovedDirectory, true);
        }

        [Test]
        public void Create()
        {
            //Arrange
            var directoryInfo = _directoryHelper.Create(testDirectory);

            //Act
            var exist = Directory.Exists(testDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(directoryInfo.Exists, Is.True);
                Assert.That(directoryInfo.Name, Is.EqualTo("myTestDirectory"));
                Assert.That(exist, Is.True);
            });
        }

        [Test]
        public void Delete_DirectoryWithContent()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            var pathSubDirectory1 = @$"{testDirectory}\sub1";
            Directory.CreateDirectory(pathSubDirectory1);

            var pathSubDirectory2 = @$"{testDirectory}\sub2";
            Directory.CreateDirectory(pathSubDirectory2);

            var pathFile1 = @$"{testDirectory}\file1.txt";
            using var streamWriter1 = new StreamWriter(pathFile1);
            streamWriter1.Close();

            var pathFile2 = @$"{testDirectory}\file2.docx";
            using var streamWriter2 = new StreamWriter(pathFile2);
            streamWriter2.Close();

            //Act
            _directoryHelper.Delete(testDirectory);

            var exist = Directory.Exists(testDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void Delete_EmptyDirectory()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            //Act
            _directoryHelper.Delete(testDirectory);

            var exist = Directory.Exists(testDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void Exists_DirectoryDoesNotExist()
        {
            //Act
            var exist = _directoryHelper.Exists(testDirectory);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void Exists_DirectoryExists()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            //Act
            var exist = _directoryHelper.Exists(testDirectory);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void Get_DirectoryDoesNotExist()
        {
            //Act
            var directoryInfo = _directoryHelper.Get(testDirectory);

            //Assert
            Assert.That(directoryInfo.Exists, Is.False);
        }

        [Test]
        public void Get_DirectoryExists()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            //Act
            var directoryInfo = _directoryHelper.Get(testDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(directoryInfo.Exists, Is.True);
                Assert.That(directoryInfo.Name, Is.EqualTo("myTestDirectory"));
            });
        }

        [Test]
        public void GetContent_DirectoryWithContent()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            var pathSubDirectory1 = @$"{testDirectory}\sub1";
            Directory.CreateDirectory(pathSubDirectory1);

            var pathSubDirectory2 = @$"{testDirectory}\sub2";
            Directory.CreateDirectory(pathSubDirectory2);

            var pathFile1 = @$"{testDirectory}\file1.txt";
            using var streamWriter1 = new StreamWriter(pathFile1);
            streamWriter1.Close();

            var pathFile2 = @$"{testDirectory}\file2.docx";
            using var streamWriter2 = new StreamWriter(pathFile2);
            streamWriter2.Close();

            //Act
            var list = _directoryHelper.GetContent(testDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list, Has.Count.EqualTo(4));
                Assert.That(list[0].Exists, Is.True);
                Assert.That(list[0].Name, Is.EqualTo("sub1"));
                Assert.That(list[1].Exists, Is.True);
                Assert.That(list[1].Name, Is.EqualTo("sub2"));
                Assert.That(list[2].Exists, Is.True);
                Assert.That(list[2].Name, Is.EqualTo("file1.txt"));
                Assert.That(list[3].Exists, Is.True);
                Assert.That(list[3].Name, Is.EqualTo("file2.docx"));
            });
        }

        [Test]
        public void GetContent_EmptyDirectory()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            //Act
            var list = _directoryHelper.GetContent(testDirectory);

            //Assert
            Assert.That(list, Is.Empty);
        }

        [Test]
        public void GetCurrentDirectory()
        {
            //Arrange
            var expected = Directory.GetCurrentDirectory();

            //Act
            var actual = _directoryHelper.GetCurrentDirectory();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetDirectories_DirectoryWithContent()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            var pathSubDirectory1 = @$"{testDirectory}\sub1";
            Directory.CreateDirectory(pathSubDirectory1);

            var pathSubDirectory2 = @$"{testDirectory}\sub2";
            Directory.CreateDirectory(pathSubDirectory2);

            //Act
            var list = _directoryHelper.GetDirectories(testDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list, Has.Count.EqualTo(2));
                Assert.That(list[0].Exists, Is.True);
                Assert.That(list[0].Name, Is.EqualTo("sub1"));
                Assert.That(list[1].Exists, Is.True);
                Assert.That(list[1].Name, Is.EqualTo("sub2"));
            });
        }

        [Test]
        public void GetDirectories_EmptyDirectory()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            //Act
            var list = _directoryHelper.GetDirectories(testDirectory);

            //Assert
            Assert.That(list, Is.Empty);
        }

        [Test]
        public void GetDirectoryRoot()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            var expected = Directory.GetDirectoryRoot(testDirectory);

            //Act
            var actual = _directoryHelper.GetDirectoryRoot(testDirectory);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetFiles_DirectoryWithContent()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            var pathFile1 = @$"{testDirectory}\file1.txt";
            using var streamWriter1 = new StreamWriter(pathFile1);
            streamWriter1.Close();

            var pathFile2 = @$"{testDirectory}\file2.docx";
            using var streamWriter2 = new StreamWriter(pathFile2);
            streamWriter2.Close();

            //Act
            var list = _directoryHelper.GetFiles(testDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(list, Has.Count.EqualTo(2));
                Assert.That(list[0].Exists, Is.True);
                Assert.That(list[0].Name, Is.EqualTo("file1.txt"));
                Assert.That(list[1].Exists, Is.True);
                Assert.That(list[1].Name, Is.EqualTo("file2.docx"));
            });
        }

        [Test]
        public void GetFiles_EmptyDirectory()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            //Act
            var list = _directoryHelper.GetFiles(testDirectory);

            //Assert
            Assert.That(list, Is.Empty);
        }

        [Test]
        public void GetLogicalDrives()
        {
            //Arrange
            var expected = Directory.GetLogicalDrives();

            //Act
            var actual = _directoryHelper.GetLogicalDrives();

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetParent()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            var expected = Directory.GetParent(testDirectory);

            //Act
            var actual = _directoryHelper.GetParent(testDirectory);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
        [Test]
        public void Move_DirectoryWithContent()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            var pathSubDirectory1 = @$"{testDirectory}\sub1";
            Directory.CreateDirectory(pathSubDirectory1);

            var pathSubDirectory2 = @$"{testDirectory}\sub2";
            Directory.CreateDirectory(pathSubDirectory2);

            var pathFile1 = @$"{testDirectory}\file1.txt";
            using var streamWriter1 = new StreamWriter(pathFile1);
            streamWriter1.Close();

            var pathFile2 = @$"{testDirectory}\file2.docx";
            using var streamWriter2 = new StreamWriter(pathFile2);
            streamWriter2.Close();

            //Act
            _directoryHelper.Move(testDirectory, testMovedDirectory);

            var sourcePathExist = Directory.Exists(testDirectory);
            var destinationPath = Directory.Exists(testMovedDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(sourcePathExist, Is.False);
                Assert.That(destinationPath, Is.True);
            });
        }

        [Test]
        public void Move_EmptyDirectory()
        {
            //Arrange
            Directory.CreateDirectory(testDirectory);

            //Act
            _directoryHelper.Move(testDirectory, testMovedDirectory);

            var sourcePathExist = Directory.Exists(testDirectory);
            var destinationPath = Directory.Exists(testMovedDirectory);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(sourcePathExist, Is.False);
                Assert.That(destinationPath, Is.True);
            });
        }
    }
}