﻿using ImageMagick;
using LSCode.Files.Files.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LSCode.Files.Files.Services
{
    /// <summary>Provides the implementation methods that help the manipulation of files.</summary>
    public class FileHelper : IFileService
    {
        /// <summary>
        ///     Appends text to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public void AppendText(string path, Encoding encoding, string text) => File.AppendAllText(path, text, encoding);

        /// <summary>
        ///     Appends text to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public void AppendText(string path, Encoding encoding, IEnumerable<string> text) => File.AppendAllLines(path, text, encoding);

        /// <summary>
        ///     Asynchronously appends text to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public async Task AppendTextAsync(string path, Encoding encoding, string text) => await File.AppendAllTextAsync(path, text, encoding);

        /// <summary>
        ///     Asynchronously appends to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public async Task AppendTextAsync(string path, Encoding encoding, IEnumerable<string> text) => await File.AppendAllLinesAsync(path, text, encoding);

        /// <summary>Compress image of the parameterized path.</summary>
        /// <remarks>Note: The original image will be replaced by the compressed image. There may be a loss of quality.</remarks>
        /// <param name="path">Path of the image to be compressed.</param>
        /// <param name="format">Image format.</param>
        /// <param name="width">Image width.</param>
        /// <param name="heigth">Image heigth.</param>
        public void Compress(string path, MagickFormat format, int width, int heigth)
        {
            using var imageMagick = new MagickImage(path);
            imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
            imageMagick.FilterType = FilterType.Spline;
            imageMagick.Resize(width, heigth);
            imageMagick.ColorType = ColorType.Palette;
            imageMagick.Format = format;
            imageMagick.Write(path);
        }

        /// <summary>Asynchronously compress image of the parameterized path.</summary>
        /// <remarks>Note: The original image will be replaced by the compressed image. There may be a loss of quality.</remarks>
        /// <param name="path">Path of the image to be compressed.</param>
        /// <param name="format">Image format.</param>
        /// <param name="width">Image width.</param>
        /// <param name="heigth">Image heigth.</param>
        public async Task CompressAsync(string path, MagickFormat format, int width, int heigth)
        {
            using var imageMagick = new MagickImage(path);
            imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
            imageMagick.FilterType = FilterType.Spline;
            imageMagick.Resize(width, heigth);
            imageMagick.ColorType = ColorType.Palette;
            imageMagick.Format = format;
            await imageMagick.WriteAsync(path);
        }

        /// <summary>Copy file with the possibility of overwriting if it already exists.</summary>
        /// <param name="sourcePath">The file to copy.</param>
        /// <param name="destinationPath">The path of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">Indicates whether or not to overwrite if the file exists.</param>
        public void Copy(string sourcePath, string destinationPath, bool overwrite = true) => File.Copy(sourcePath, destinationPath, overwrite);

        /// <summary>Creates a empty file of any extension.</summary>
        /// <param name="path">The path of the file to create.</param>
        public void Create(string path)
        {
            using var streamWriter = new StreamWriter(path);
            streamWriter.Close();
        }

        /// <summary>Creates a file from a base64String.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="base64String">File content in base64String.</param>
        public void CreateFromBase64String(string path, string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            using var fileStream = File.Create(path);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        /// <summary>Asynchronously creates a file from a base64String.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="base64String">File content in base64String.</param>
        public async Task CreateFromBase64StringAsync(string path, string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            using var fileStream = File.Create(path);
            await fileStream.WriteAsync(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        /// <summary>Creates a file from a byte array.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="byteArray">File content in bytes.</param>
        public void CreateFromBytes(string path, byte[] byteArray)
        {
            using var fileStream = File.Create(path);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        /// <summary>Asynchronously creates a file from a byte array.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="byteArray">File content in bytes.</param>
        public async Task CreateFromBytesAsync(string path, byte[] byteArray)
        {
            using var fileStream = File.Create(path);
            await fileStream.WriteAsync(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        /// <summary>
        ///     Creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public void CreateTextFile(string path, Encoding encoding, string text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            streamWriter.Write(text);
            streamWriter.Close();
        }

        /// <summary>
        ///     Creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public void CreateTextFile(string path, Encoding encoding, IEnumerable<string> text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in text)
                streamWriter.WriteLine(item);

            streamWriter.Close();
        }

        /// <summary>
        ///     Asynchronously creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public async Task CreateTextFileAsync(string path, Encoding encoding, string text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            await streamWriter.WriteAsync(text);
            streamWriter.Close();
        }

        /// <summary>
        ///     Asynchronously creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        public async Task CreateTextFileAsync(string path, Encoding encoding, IEnumerable<string> text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in text)
                await streamWriter.WriteLineAsync(item);

            streamWriter.Close();
        }

        /// <summary>Deletes the specified file.</summary>
        /// <param name="path">The path of the file to be deleted. Wildcard characters are not supported.</param>
        public void Delete(string path) => File.Delete(path);

        /// <summary>Decrypts the desired file, replacing the original file with the encrypted version.</summary>
        /// <param name="sourcePath">A path that describes a file to encrypt.</param>
        /// <param name="secret">Key to encrypt and decrypt the file.</param>
        public void Decrypt(string sourcePath, string secret)
        {
            var secretBytes = new UnicodeEncoding().GetBytes(secret);

            using var fileStream = new FileStream(sourcePath, FileMode.Open);

            using var RMCrypto = new RijndaelManaged();

            using var cryptoStream = new CryptoStream(fileStream, RMCrypto.CreateDecryptor(secretBytes, secretBytes), CryptoStreamMode.Read);

            int data;
            var fileBytes = new List<byte>();
            while ((data = cryptoStream.ReadByte()) != -1)
                fileBytes.Add((byte)data);

            cryptoStream.Close();

            fileStream.Close();

            using var fileStreamOut = new FileStream(sourcePath, FileMode.Create);

            foreach (var item in fileBytes)
                fileStreamOut.WriteByte(item);

            fileStreamOut.Close();
        }

        /// <summary>Encrypts desired file, replacing the original file with the encrypted version.</summary>
        /// <param name="sourcePath">A path that describes a file to encrypt.</param>
        /// <param name="secret">Key to encrypt and decrypt the file.</param>
        public void Encrypt(string sourcePath, string secret)
        {
            var fileBytes = File.ReadAllBytes(sourcePath);

            var secretBytes = new UnicodeEncoding().GetBytes(secret);

            using var fileStream = new FileStream(sourcePath, FileMode.Create);

            using var RMCrypto = new RijndaelManaged();

            using var cryptoStream = new CryptoStream(fileStream, RMCrypto.CreateEncryptor(secretBytes, secretBytes), CryptoStreamMode.Write);

            foreach (byte b in fileBytes)
                cryptoStream.WriteByte(b);

            cryptoStream.Close();

            fileStream.Close();
        }

        /// <summary>Determines whether the specified file exists.</summary>
        /// <param name="path">The file to check.</param>
        /// <returns>
        ///     True if the caller has the required permissions and path contains the name of
        ///     an existing file; otherwise, false. This method also returns false if path is
        ///     null, an invalid path, or a zero-length string. If the caller does not have sufficient
        ///     permissions to read the specified file, no exception is thrown and the method
        ///     returns false regardless of the existence of path.
        /// </returns>
        public bool Exists(string path) => File.Exists(path);

        /// <summary>Get information from the desired file.</summary>
        /// <param name="path">File path to get your informations.</param>
        /// <returns>File informations.</returns>
        public FileInfo Get(string path) => new FileInfo(path);

        /// <summary>Move file without possibility to overwrite if it already exists.</summary>
        /// <param name="sourcePath">The path of the file to move. Can include a relative or absolute path.</param>
        /// <param name="destinationPath">The new path and name for the file.</param>
        public void Move(string sourcePath, string destinationPath) => File.Move(sourcePath, destinationPath);

        /// <summary>Opens a FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.</summary>
        /// <param name="path">The file to open.</param>
        /// <param name="mode">A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.</param>
        /// <param name="access">A FileAccess value that specifies the operations that can be performed on the file.</param>
        /// <param name="share">A FileShare value specifying the type of access other threads have to the file.</param>
        /// <returns>A FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.</returns>
        public FileStream Open(string path, FileMode mode, FileAccess access, FileShare share) => File.Open(path, mode, access, share);

        /// <summary>Opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        public string ReadToBase64String(string path) => Convert.ToBase64String(File.ReadAllBytes(path));

        /// <summary>Asynchronously opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        public async Task<string> ReadToBase64StringAsync(string path) => Convert.ToBase64String(await File.ReadAllBytesAsync(path));

        /// <summary>Opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public byte[] ReadToBytes(string path) => File.ReadAllBytes(path);

        /// <summary>Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public async Task<byte[]> ReadToBytesAsync(string path) => await File.ReadAllBytesAsync(path);

        /// <summary>Opens a text file, reads all lines of the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public string[] ReadLines(string path) => File.ReadAllLines(path);

        /// <summary>Asynchronously opens a text file, reads all lines of the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        public async Task<string[]> ReadLinesAsync(string path) => await File.ReadAllLinesAsync(path);

        /// <summary>Opens a text file, reads all the text in the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all the text in the file.</returns>
        public string ReadText(string path) => File.ReadAllText(path);

        /// <summary>Asynchronously opens a text file, reads all the text in the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all the text in the file.</returns>
        public async Task<string> ReadTextAsync(string path) => await File.ReadAllTextAsync(path);
    }
}