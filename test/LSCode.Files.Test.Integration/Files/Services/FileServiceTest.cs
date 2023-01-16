using ImageMagick;
using LSCode.Files.Files.Interfaces;
using LSCode.Files.Files.Services;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LSCode.Files.Test.Integration.Files.Services
{
    internal class FileServiceTest
    {
        private readonly static string testDirectory = @$"{AppDomain.CurrentDomain.BaseDirectory}\myTestDirectory";
        private readonly static string testFileTxt = @$"{testDirectory}\file.txt";
        private readonly static string testFilePng = @$"{testDirectory}\file.png";

        private readonly IFileService _fileService;

        public FileServiceTest() => _fileService = new FileHelper();

        [SetUp]
        public void SetUp()
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);

            Directory.CreateDirectory(testDirectory);
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(testDirectory))
                Directory.Delete(testDirectory, true);
        }

        [Test]
        public void AppendText_TextAsString_NewFile()
        {
            //Arrange
            var text = "File content";

            //Act
            _fileService.AppendText(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public void AppendText_TextAsString_FileWithoutText()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            _fileService.AppendText(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public void AppendText_TextAsString_FileWithText()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            _fileService.AppendText(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo($"{text}{text}"));
            });
        }

        [Test]
        public void AppendText_TextAsListOfString_NewFile()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            //Act
            _fileService.AppendText(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public void AppendText_TextAsListOfString_FileWithoutText()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            _fileService.AppendText(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public void AppendText_TextAsListOfString_FileWithText()
        {
            //Arrange
            string[] text = { "File content", "File content" };
            string[] expectedText = { "File content", "File content", "File content", "File content" };

            using var streamWriter = new StreamWriter(testFileTxt);

            foreach (var item in text)
                streamWriter.WriteLine(item);

            streamWriter.Close();

            //Act
            _fileService.AppendText(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(expectedText));
            });
        }

        [Test]
        public async Task AppendTextAsync_TextAsString_NewFile()
        {
            //Arrange
            var text = "File content";

            //Act
            await _fileService.AppendTextAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public async Task AppendTextAsync_TextAsString_FileWithoutText()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            await _fileService.AppendTextAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public async Task AppendTextAsync_TextAsString_FileWithText()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            await _fileService.AppendTextAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo($"{text}{text}"));
            });
        }

        [Test]
        public async Task AppendTextAsync_TextAsListOfString_NewFile()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            //Act
            await _fileService.AppendTextAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public async Task AppendTextAsync_TextAsListOfString_FileWithoutText()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            await _fileService.AppendTextAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public async Task AppendTextAsync_TextAsListOfString_FileWithText()
        {
            //Arrange
            string[] text = { "File content", "File content" };
            string[] expectedText = { "File content", "File content", "File content", "File content" };

            using var streamWriter = new StreamWriter(testFileTxt);

            foreach (var item in text)
                streamWriter.WriteLine(item);

            streamWriter.Close();

            //Act
            await _fileService.AppendTextAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(expectedText));
            });
        }

        [Test]
        public void Compress()
        {
            //Arrange
            var imageBase64String = "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";
            var imageBytes = Convert.FromBase64String(imageBase64String);
            using var fileStream = File.Create(testFilePng);
            fileStream.Write(imageBytes, 0, imageBytes.Length);
            fileStream.Close();

            var originalSize = new FileInfo(testFilePng).Length;

            //Act
            _fileService.Compress(testFilePng, MagickFormat.Png, 50, 50);

            var compressedSize = new FileInfo(testFilePng).Length;

            var exist = File.Exists(testFilePng);
            var compressedWithSuccess = compressedSize < originalSize;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(compressedWithSuccess, Is.True);
            });
        }

        [Test]
        public async Task CompressAsync()
        {
            //Arrange
            var imageBase64String = "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";
            var imageBytes = Convert.FromBase64String(imageBase64String);
            using var fileStream = File.Create(testFilePng);
            fileStream.Write(imageBytes, 0, imageBytes.Length);
            fileStream.Close();

            var originalSize = new FileInfo(testFilePng).Length;

            //Act
            await _fileService.CompressAsync(testFilePng, MagickFormat.Png, 50, 50);

            var compressedSize = new FileInfo(testFilePng).Length;

            var exist = File.Exists(testFilePng);
            var compressedWithSuccess = compressedSize < originalSize;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(compressedWithSuccess, Is.True);
            });
        }

        [Test]
        public void Copy_WithoutOverwritingExistingFile()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            Directory.CreateDirectory(@$"{testDirectory}\newPath");

            var testFileToCopy = @$"{testDirectory}\newPath\fileCopied.txt";

            //Act
            _fileService.Copy(testFileTxt, testFileToCopy);

            var originalFileExist = File.Exists(testFileTxt);
            var copiedFileExist = File.Exists(testFileToCopy);
            var copiedFileContent = File.ReadAllText(testFileToCopy);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(originalFileExist, Is.True);
                Assert.That(copiedFileExist, Is.True);
                Assert.That(copiedFileContent, Is.EqualTo(text));
            });
        }

        [Test]
        public void Copy_OverwritingExistingFile()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            Directory.CreateDirectory(@$"{testDirectory}\newPath");

            var testFileToCopy = @$"{testDirectory}\newPath\fileCopied.txt";

            using var streamWriter2 = new StreamWriter(testFileToCopy);
            streamWriter2.Write($@"File to be overwritten");
            streamWriter2.Close();

            //Act
            _fileService.Copy(testFileTxt, testFileToCopy, true);

            var originalFileExist = File.Exists(testFileTxt);
            var copiedFileExist = File.Exists(testFileToCopy);
            var copiedFileContent = File.ReadAllText(testFileToCopy);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(originalFileExist, Is.True);
                Assert.That(copiedFileExist, Is.True);
                Assert.That(copiedFileContent, Is.EqualTo(text));
            });
        }

        [Test]
        public void Create()
        {
            //Act
            _fileService.Create(testFileTxt);

            var exist = File.Exists(testFileTxt);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void CreateFromBase64String()
        {
            //Arrange
            var fileBase64String = "RmlsZSBjb250ZW50";

            //Act
            _fileService.CreateFromBase64String(testFileTxt, fileBase64String);

            var fileInfo = new FileInfo(testFileTxt);

            var exist = File.Exists(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(fileInfo.Length, Is.EqualTo(12));
                Assert.That(fileInfo.Name, Is.EqualTo("file.txt"));
            });
        }

        [Test]
        public async Task CreateFromBase64StringAsync()
        {
            //Arrange
            var fileBase64String = "RmlsZSBjb250ZW50";

            //Act
            await _fileService.CreateFromBase64StringAsync(testFileTxt, fileBase64String);

            var fileInfo = new FileInfo(testFileTxt);

            var exist = File.Exists(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(fileInfo.Length, Is.EqualTo(12));
                Assert.That(fileInfo.Name, Is.EqualTo("file.txt"));
            });
        }

        [Test]
        public void CreateFromBytes()
        {
            //Arrange
            var fileBase64String = "RmlsZSBjb250ZW50";
            var imageBytes = Convert.FromBase64String(fileBase64String);

            //Act
            _fileService.CreateFromBytes(testFileTxt, imageBytes);

            var fileInfo = new FileInfo(testFileTxt);

            var exist = File.Exists(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(fileInfo.Length, Is.EqualTo(12));
                Assert.That(fileInfo.Name, Is.EqualTo("file.txt"));
            });
        }

        [Test]
        public async Task CreateFromBytesAsync()
        {
            //Arrange
            var fileBase64String = "RmlsZSBjb250ZW50";
            var imageBytes = Convert.FromBase64String(fileBase64String);

            //Act
            await _fileService.CreateFromBytesAsync(testFileTxt, imageBytes);

            var fileInfo = new FileInfo(testFileTxt);

            var exist = File.Exists(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(fileInfo.Length, Is.EqualTo(12));
                Assert.That(fileInfo.Name, Is.EqualTo("file.txt"));
            });
        }

        [Test]
        public void CreateTextFile_TextAsString()
        {
            //Arrange
            var text = "File content";

            //Act
            _fileService.CreateTextFile(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public void CreateTextFile_TextAsListofString()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            //Act
            _fileService.CreateTextFile(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public async Task CreateTextFileAsync_TextAsString()
        {
            //Arrange
            var text = "File content";

            //Act
            await _fileService.CreateTextFileAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public async Task CreateTextFileAsync_TextAsListofString()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            //Act
            await _fileService.CreateTextFileAsync(testFileTxt, Encoding.UTF8, text);

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllLines(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public void Delete_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            _fileService.Delete(testFileTxt);

            var exist = File.Exists(testFileTxt);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void Delete_FileDoesNotExist()
        {
            //Act
            _fileService.Delete(testFileTxt);

            var exist = File.Exists(testFileTxt);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void Decrypt()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            _fileService.Encrypt(testFileTxt, "myKey123");

            //Act
            _fileService.Decrypt(testFileTxt, "myKey123");

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);
            var bytes = File.ReadAllBytes(testFileTxt);
            var base64String = Convert.ToBase64String(bytes);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
                Assert.That(bytes.Length, Is.EqualTo(12));
                Assert.That(base64String, Is.EqualTo("RmlsZSBjb250ZW50"));
            });
        }

        [Test]
        public void Encrypt()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            _fileService.Encrypt(testFileTxt, "myKey123");

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);
            var bytes = File.ReadAllBytes(testFileTxt);
            var base64String = Convert.ToBase64String(bytes);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo("�\u0002��Yı\r��I�(\u00194"));
                Assert.That(bytes.Length, Is.EqualTo(16));
                Assert.That(base64String, Is.EqualTo("5L4CpfZZxLENsOpJjCgZNA=="));
            });
        }

        [Test]
        public void Exists_FileDoesNotExist()
        {
            //Act
            var exist = _fileService.Exists(testFileTxt);

            //Assert
            Assert.That(exist, Is.False);
        }

        [Test]
        public void Exists_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var exist = _fileService.Exists(testFileTxt);

            //Assert
            Assert.That(exist, Is.True);
        }

        [Test]
        public void Get_FileDoesNotExist()
        {
            //Act
            var fileInfo = _fileService.Get(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(fileInfo.Exists, Is.False);
                Assert.That(fileInfo.Name, Is.EqualTo("file.txt"));
            });
        }

        [Test]
        public void Get_FileExists()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var fileInfo = _fileService.Get(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(fileInfo.Exists, Is.True);
                Assert.That(fileInfo.Name, Is.EqualTo("file.txt"));
                Assert.That(fileInfo.Length, Is.Zero);
            });
        }

        [Test]
        public void Move()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            Directory.CreateDirectory(@$"{testDirectory}\newPath");

            var testFileToMove = @$"{testDirectory}\newPath\fileMoved.txt";

            //Act
            _fileService.Move(testFileTxt, testFileToMove);

            var originalFileExist = File.Exists(testFileTxt);
            var movedFileExist = File.Exists(testFileToMove);
            var movedFileContent = File.ReadAllText(testFileToMove);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(originalFileExist, Is.False);
                Assert.That(movedFileExist, Is.True);
                Assert.That(movedFileContent, Is.EqualTo(text));
            });
        }

        [Test]
        public void Open()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            using var fileStream = _fileService.Open(testFileTxt, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            var info = new UTF8Encoding(true).GetBytes(text);
            fileStream.Write(info, 0, info.Length);
            fileStream.Close();

            var exist = File.Exists(testFileTxt);
            var content = File.ReadAllText(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(exist, Is.True);
                Assert.That(content, Is.EqualTo(text));
            });
        }

        [Test]
        public void ReadToBase64String_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = _fileService.ReadToBase64String(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public void ReadToBase64String_FileWithContent()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            var content = _fileService.ReadToBase64String(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(content, Is.Not.Empty);
                Assert.That(content, Has.Length.EqualTo(16));
                Assert.That(content, Is.EqualTo("RmlsZSBjb250ZW50"));
            });
        }

        [Test]
        public async Task ReadToBase64StringAsync_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = await _fileService.ReadToBase64StringAsync(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public async Task ReadToBase64StringAsync_FileWithContent()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            var content = await _fileService.ReadToBase64StringAsync(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(content, Is.Not.Empty);
                Assert.That(content, Has.Length.EqualTo(16));
                Assert.That(content, Is.EqualTo("RmlsZSBjb250ZW50"));
            });
        }

        [Test]
        public void ReadToBytes_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = _fileService.ReadToBytes(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public void ReadToBytes_FileWithContent()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            var content = _fileService.ReadToBytes(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(content, Is.Not.Empty);
                Assert.That(content, Has.Length.EqualTo(12));
            });
        }

        [Test]
        public async Task ReadToBytesAsync_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = await _fileService.ReadToBytesAsync(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public async Task ReadToBytesAsync_FileWithContent()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            var content = await _fileService.ReadToBytesAsync(testFileTxt);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(content, Is.Not.Empty);
                Assert.That(content, Has.Length.EqualTo(12));
            });
        }

        [Test]
        public void ReadLines_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = _fileService.ReadLines(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public void ReadLines_FileWithContent()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            using var streamWriter = new StreamWriter(testFileTxt);

            foreach (var line in text)
                streamWriter.WriteLine(line);

            streamWriter.Close();

            //Act
            var content = _fileService.ReadLines(testFileTxt);

            //Assert
            Assert.That(content, Is.EqualTo(text));
        }

        [Test]
        public async Task ReadLinesAsync_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = await _fileService.ReadLinesAsync(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public async Task ReadLinesAsync_FileWithContent()
        {
            //Arrange
            string[] text = { "File content", "File content" };

            using var streamWriter = new StreamWriter(testFileTxt);

            foreach (var line in text)
                streamWriter.WriteLine(line);

            streamWriter.Close();

            //Act
            var content = await _fileService.ReadLinesAsync(testFileTxt);

            //Assert
            Assert.That(content, Is.EqualTo(text));
        }

        [Test]
        public void ReadText_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = _fileService.ReadText(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public void ReadText_FileWithContent()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            var content = _fileService.ReadText(testFileTxt);

            //Assert
            Assert.That(content, Is.EqualTo(text));
        }

        [Test]
        public async Task ReadTextAsync_EmptyFile()
        {
            //Arrange
            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Close();

            //Act
            var content = await _fileService.ReadTextAsync(testFileTxt);

            //Assert
            Assert.That(content, Is.Empty);
        }

        [Test]
        public async Task ReadTextAsync_FileWithContent()
        {
            //Arrange
            var text = "File content";

            using var streamWriter = new StreamWriter(testFileTxt);
            streamWriter.Write(text);
            streamWriter.Close();

            //Act
            var content = await _fileService.ReadTextAsync(testFileTxt);

            //Assert
            Assert.That(content, Is.EqualTo(text));
        }
    }
}