using LSCode.Files.Files;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace LSCode.Files.Test.Unit.Files
{
    internal class FileHelperTest
    {
        private readonly static string testDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\myTestDirectory";
        private readonly static string testFile = @$"{testDirectory}\file1.txt";
        private readonly static string testMovedFile = @$"{testDirectory}\file1.txt";

        [SetUp]
        public void SetUp() => Directory.CreateDirectory(testDirectory);

        [Test]
        public void Create()
        {
            FileHelper.Create(testFile);

            var exist = File.Exists(testFile);

            Assert.That(exist, Is.True);
        }

        [Test]
        [TestCase("file.txt")]
        [TestCase("file.cs")]
        [TestCase("file.html")]
        [TestCase("file.css")]
        public void Create_WithContent_AllText(string path)
        {
            var testFilePath = $@"{testDirectory}\{path}";

            var content = "File content";

            FileHelper.CreateTextFile(testFilePath, Encoding.UTF8, content);

            var exist = File.Exists(testFilePath);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void Exists_FileDoesNotExist()
        {
            var exist = FileHelper.Exists(testFile);

            Assert.That(exist, Is.False);
        }

        [Test]
        public void Exists_FileExists()
        {
            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Close();

            var exist = FileHelper.Exists(testFile);

            Assert.That(exist, Is.True);
        }

        [Test]
        public void ReadToBytes_EmptyFile()
        {
            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Close();

            var bytes = FileHelper.ReadToBytes(testFile);

            Assert.That(bytes, Is.Empty);
        }

        [Test]
        public void ReadToBytes_FileWithContent()
        {
            var content = "File content";

            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Write(content);
            streamWriter.Close();

            var bytes = FileHelper.ReadToBytes(testFile);

            Assert.That(bytes, Is.Not.Empty);
            Assert.That(bytes, Has.Length.EqualTo(12));
        }

        [Test]
        public void ReadToBase64String_EmptyFile()
        {
            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Close();

            var bytes = FileHelper.ReadToBase64String(testFile);

            Assert.That(bytes, Is.Empty);
        }

        [Test]
        public void ReadToBase64String_FileWithContent()
        {
            var content = "File content";

            using var streamWriter = new StreamWriter(testFile);
            streamWriter.Write(content);
            streamWriter.Close();

            var base64String = FileHelper.ReadToBase64String(testFile);

            Assert.That(base64String, Is.Not.Empty);
            Assert.That(base64String, Has.Length.EqualTo(16));
            Assert.That(base64String, Is.EqualTo("RmlsZSBjb250ZW50"));
        }

        [TearDown]
        public void TearDown() => Directory.Delete(testDirectory, true);
    }
}