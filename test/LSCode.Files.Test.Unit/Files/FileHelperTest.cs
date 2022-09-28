using LSCode.Files.Files;
using LSCode.Files.Files.Interfaces;
using NUnit.Framework;
using System;

namespace LSCode.Files.Test.Unit.Files
{
    internal class FileHelperTest
    {
        private readonly string testFile = @$"{AppDomain.CurrentDomain.BaseDirectory}\myTestDirectory\file1.txt";
        private readonly string testMovedFile = @$"{AppDomain.CurrentDomain.BaseDirectory}\myMovedTestDirectory\file1.txt";

        private readonly IFileHelper _fileHelper;

        public FileHelperTest() => _fileHelper = new FileHelper();

        [SetUp]
        public void SetUp() { }

        [TearDown]
        public void TearDown() { }
    }
}