using LSCode.Files.Files;
using LSCode.Files.Files.Interfaces;
using NUnit.Framework;
using System;
using System.IO;

namespace LSCode.Files.Test.Unit.Files
{
    internal class FileHelperTest
    {
        private readonly static string testDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\myTestDirectory";
        private readonly static string testFile = @$"{testDirectory}\file1.txt";
        private readonly static string testMovedFile = @$"{testDirectory}\file1.txt";

        private readonly IFileHelper _fileHelper;

        public FileHelperTest() => _fileHelper = new FileHelper();

        [SetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(testDirectory);

            if (File.Exists(testFile))
                File.Delete(testFile);

            if (File.Exists(testMovedFile))
                File.Delete(testMovedFile);
        }

        [Test]
        public void Exists_FileExists()
        {
            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Close();

            var exist = _fileHelper.Exists(testFile);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void Exists_FileDoesNotExist()
        {
            var exist = _fileHelper.Exists(testFile);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void ReadToBytes_EmptyFile()
        {
            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Close();

            var bytes = _fileHelper.ReadToBytes(testFile);

            Assert.That(bytes, Is.Empty);
        }

        [Test]
        public void ReadToBytes_FileWithContent()
        {
            var content = "File content";

            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Write(content);
            streamWriter.Close();

            var bytes = _fileHelper.ReadToBytes(testFile);

            Assert.That(bytes, Is.Not.Empty);
            Assert.That(bytes, Has.Length.EqualTo(12));
        }

        [Test]
        public void ReadToBase64String_EmptyFile()
        {
            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Close();

            var bytes = _fileHelper.ReadToBase64String(testFile);

            Assert.That(bytes, Is.Empty);
        }

        [Test]
        public void ReadToBase64String_FileWithContent()
        {
            var content = "File content";

            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Write(content);
            streamWriter.Close();

            var base64String = _fileHelper.ReadToBase64String(testFile);

            Assert.That(base64String, Is.Not.Empty);
            Assert.That(base64String, Has.Length.EqualTo(16));
            Assert.That(base64String, Is.EqualTo("RmlsZSBjb250ZW50"));
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(testDirectory, true);

            if (File.Exists(testFile))
                File.Delete(testFile);

            if (File.Exists(testMovedFile))
                File.Delete(testMovedFile);
        }
    }
}