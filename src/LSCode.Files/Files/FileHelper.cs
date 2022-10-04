using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LSCode.Files.Files
{
    /// <summary>Helper that assists in files manipulations.</summary>
    public static class FileHelper
    {
        /// <summary>Compact image of the parameterized path.</summary>
        /// <remarks>Note: The original image will be replaced by the compressed image. There may be a loss of quality.</remarks>
        /// <param name="path">Path of the image to be compressed.</param>
        /// <param name="format">Image format.</param>
        /// <param name="width">Image width.</param>
        /// <param name="heigth">Image heigth.</param>
        public static void Compress(string path, MagickFormat format, int width, int heigth)
        {
            using var imageMagick = new MagickImage(path);
            imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
            imageMagick.FilterType = FilterType.Spline;
            imageMagick.Resize(width, heigth);
            imageMagick.ColorType = ColorType.Palette;
            imageMagick.Format = format;
            imageMagick.Write(path);
        }

        /// <summary>Copy file with the possibility of overwriting if it already exists.</summary>
        /// <param name="sourcePath">The file to copy.</param>
        /// <param name="destinationPath">The path of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">Indicates whether or not to overwrite if the file exists.</param>
        public static void Copy(string sourcePath, string destinationPath, bool overwrite = true) => File.Copy(sourcePath, destinationPath, overwrite);

        /// <summary>Creates a empty file of any extension.</summary>
        /// <param name="path">The path of the file to create.</param>
        public static void Create(string path)
        {
            using var streamWriter = new StreamWriter(path);
            streamWriter.Close();
        }

        /// <summary>Creates a file from a base64String.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="base64String">File content in base64String.</param>
        public static void CreateFromBase64String(string path, string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            using var fileStream = File.Create(path);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        /// <summary>Asynchronously creates a file from a base64String.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="base64String">File content in base64String.</param>
        public static async Task CreateFromBase64StringAsync(string path, string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            using var fileStream = File.Create(path);
            await fileStream.WriteAsync(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        /// <summary>Creates a file from a byte array.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="byteArray">File content in bytes.</param>
        public static void CreateFromBytes(string path, byte[] byteArray)
        {
            using var fileStream = File.Create(path);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        /// <summary>Asynchronously creates a file from a byte array.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="byteArray">File content in bytes.</param>
        public static async Task CreateFromBytesAsync(string path, byte[] byteArray)
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
        /// <param name="stringBuilder">Text file content.</param>
        public static void CreateTextFile(string path, Encoding encoding, StringBuilder stringBuilder)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            streamWriter.Write(stringBuilder.ToString());
            streamWriter.Close();
        }

        /// <summary>
        ///     Asynchronously creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="stringBuilder">Text file content.</param>
        public static async Task CreateTextFileAsync(string path, Encoding encoding, StringBuilder stringBuilder)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            await streamWriter.WriteAsync(stringBuilder.ToString());
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
        public static void CreateTextFile(string path, Encoding encoding, string text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            streamWriter.Write(text);
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
        public static async Task CreateTextFileAsync(string path, Encoding encoding, string text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            await streamWriter.WriteAsync(text);
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
        public static void CreateTextFile(string path, Encoding encoding, string[] text)
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
        public static async Task CreateTextFileAsync(string path, Encoding encoding, string[] text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in text)
                await streamWriter.WriteLineAsync(item);

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
        public static void CreateTextFile(string path, Encoding encoding, List<string> text)
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
        public static async Task CreateTextFileAsync(string path, Encoding encoding, List<string> text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in text)
                await streamWriter.WriteLineAsync(item);

            streamWriter.Close();
        }

        /// <summary>Deletes the specified file.</summary>
        /// <param name="filePath">The path of the file to be deleted. Wildcard characters are not supported.</param>
        public static void Delete(string filePath) => File.Delete(filePath);

        /// <summary>Determines whether the specified file exists.</summary>
        /// <param name="path">The file to check.</param>
        /// <returns>
        ///     True if the caller has the required permissions and path contains the name of
        ///     an existing file; otherwise, false. This method also returns false if path is
        ///     null, an invalid path, or a zero-length string. If the caller does not have sufficient
        ///     permissions to read the specified file, no exception is thrown and the method
        ///     returns false regardless of the existence of path.
        /// </returns>
        public static bool Exists(string path) => File.Exists(path);

        /// <summary>Move file without possibility to overwrite if it already exists.</summary>
        /// <param name="sourcePath">The path of the file to move. Can include a relative or absolute path.</param>
        /// <param name="destinationPath">The new path and name for the file.</param>
        public static void Move(string sourcePath, string destinationPath) => File.Move(sourcePath, destinationPath);

        /// <summary>Opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        public static string ReadToBase64String(string path) => Convert.ToBase64String(File.ReadAllBytes(path));

        /// <summary>Asynchronously opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        public static async Task<string> ReadToBase64StringAsync(string path) => Convert.ToBase64String(await File.ReadAllBytesAsync(path));

        /// <summary>Opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public static byte[] ReadToBytes(string path) => File.ReadAllBytes(path);

        /// <summary>Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public static async Task<byte[]> ReadToBytesAsync(string path) => await File.ReadAllBytesAsync(path);
    }
}