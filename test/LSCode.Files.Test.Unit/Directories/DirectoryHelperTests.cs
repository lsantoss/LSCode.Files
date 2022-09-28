using LSCode.Files.Directories;
using LSCode.Files.Directories.Interfaces;
using NUnit.Framework;
using System;
using System.IO;

namespace LSCode.Files.Test.Unit.Directories
{
    internal class DirectoryHelperTests
    {
        private readonly string testDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\myTestDirectory";
        private readonly string testMovedDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\myMovedTestDirectory";

        private readonly IDirectoryHelper _directoryHelper;

        public DirectoryHelperTests() => _directoryHelper = new DirectoryHelper();

        [SetUp]
        public void SetUp()
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);

            if (Directory.Exists(testMovedDirectory))
                Directory.Delete(testMovedDirectory, true);
        }

        [Test]
        public void Exists_DirectoryExists()
        {
            Directory.CreateDirectory(testDirectory);

            var exist = _directoryHelper.Exists(testDirectory);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void Exists_DirectoryDoesNotExist()
        {
            var exist = _directoryHelper.Exists(testDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void Get_DirectoryExists()
        {
            Directory.CreateDirectory(testDirectory);

            var directoryInfo = _directoryHelper.Get(testDirectory);
            
            Assert.Multiple(() =>
            {
                Assert.That(directoryInfo.Exists, Is.True);
                Assert.That(directoryInfo.Name, Is.EqualTo("myTestDirectory"));
            });
        }

        [Test]
        public void Get_DirectoryDoesNotExist()
        {
            var directoryInfo = _directoryHelper.Get(testDirectory);

            Assert.That(directoryInfo.Exists, Is.False);
        }

        [Test]
        public void Create()
        {
            var directoryInfo =_directoryHelper.Create(testDirectory);

            var exist = Directory.Exists(testDirectory);

            Assert.Multiple(() =>
            {
                Assert.That(directoryInfo.Exists, Is.True);
                Assert.That(directoryInfo.Name, Is.EqualTo("myTestDirectory"));
                Assert.That(exist, Is.True);
            });
        }

        [Test]
        public void Delete_EmptyDirectory()
        {
            Directory.CreateDirectory(testDirectory);

            _directoryHelper.Delete(testDirectory);

            var exist = Directory.Exists(testDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void Delete_DirectoryWithContent()
        {
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

            _directoryHelper.Delete(testDirectory);

            var exist = Directory.Exists(testDirectory);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void Move_EmptyDirectory()
        {
            Directory.CreateDirectory(testDirectory);

            _directoryHelper.Move(testDirectory, testMovedDirectory);

            var sourcePathExist = Directory.Exists(testDirectory);
            var destinationPath = Directory.Exists(testMovedDirectory);
            
            Assert.Multiple(() =>
            {
                Assert.That(sourcePathExist, Is.False);
                Assert.That(destinationPath, Is.True);
            });
        }

        [Test]
        public void Move_DirectoryWithContent()
        {
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

            _directoryHelper.Move(testDirectory, testMovedDirectory);

            var sourcePathExist = Directory.Exists(testDirectory);
            var destinationPath = Directory.Exists(testMovedDirectory);
            
            Assert.Multiple(() =>
            {
                Assert.That(sourcePathExist, Is.False);
                Assert.That(destinationPath, Is.True);
            });
        }

        [Test]
        public void GetParent()
        {
            Directory.CreateDirectory(testDirectory);

            var expected = Directory.GetParent(testDirectory);
            var actual = _directoryHelper.GetParent(testDirectory);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetDirectories_EmptyDirectory()
        {
            Directory.CreateDirectory(testDirectory);

            var list = _directoryHelper.GetDirectories(testDirectory);

            Assert.That(list, Is.Empty);
        }

        [Test]
        public void GetDirectories_DirectoryWithContent()
        {
            Directory.CreateDirectory(testDirectory);

            var pathSubDirectory1 = @$"{testDirectory}\sub1";
            Directory.CreateDirectory(pathSubDirectory1);

            var pathSubDirectory2 = @$"{testDirectory}\sub2";
            Directory.CreateDirectory(pathSubDirectory2);

            var list = _directoryHelper.GetDirectories(testDirectory);

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
        public void GetFiles_EmptyDirectory()
        {
            Directory.CreateDirectory(testDirectory);

            var list = _directoryHelper.GetFiles(testDirectory);

            Assert.That(list, Is.Empty);
        }

        [Test]
        public void GetFiles_DirectoryWithContent()
        {
            Directory.CreateDirectory(testDirectory);

            var pathFile1 = @$"{testDirectory}\file1.txt";
            using var streamWriter1 = new StreamWriter(pathFile1);
            streamWriter1.Close();

            var pathFile2 = @$"{testDirectory}\file2.docx";
            using var streamWriter2 = new StreamWriter(pathFile2);
            streamWriter2.Close();

            var list = _directoryHelper.GetFiles(testDirectory);

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
        public void GetContent_EmptyDirectory()
        {
            Directory.CreateDirectory(testDirectory);

            var list = _directoryHelper.GetContent(testDirectory);

            Assert.That(list, Is.Empty);
        }

        [Test]
        public void GetContent_DirectoryWithContent()
        {
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

            var list = _directoryHelper.GetContent(testDirectory);

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
        public void GetCurrentDirectory()
        {
            var expected = Directory.GetCurrentDirectory();
            var actual = _directoryHelper.GetCurrentDirectory();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetDirectoryRoot()
        {
            Directory.CreateDirectory(testDirectory);

            var expected = Directory.GetDirectoryRoot(testDirectory);
            var actual = _directoryHelper.GetDirectoryRoot(testDirectory);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetLogicalDrives()
        {
            var expected = Directory.GetLogicalDrives();
            var actual = _directoryHelper.GetLogicalDrives();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);

            if (Directory.Exists(testMovedDirectory))
                Directory.Delete(testMovedDirectory, true);
        }
    }
}