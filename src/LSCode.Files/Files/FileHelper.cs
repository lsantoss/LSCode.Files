using ImageMagick;
using System;
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
        /// <param name="imagePath">Path of the image to be compressed.</param>
        /// <exception cref="Exception">Error compressing image.</exception>
        public static void Compress(string imagePath)
        {
            using (var imageMagick = new MagickImage(imagePath))
            {
                imageMagick.Transparent(MagickColor.FromRgb(0, 0, 0));
                imageMagick.FilterType = FilterType.Spline;
                imageMagick.Resize(2520, 3500);
                imageMagick.ColorType = ColorType.Palette;
                imageMagick.Format = MagickFormat.Png8;
                imageMagick.Write(imagePath);
            }
        }

        /// <summary>Copy file with the possibility of overwriting if it already exists.</summary>
        /// <param name="filePath">Path of the file to be copied.</param>
        /// <param name="destinationPath">File copy destination path.</param>
        /// <param name="overwrite">Indicates whether or not to overwrite if the file exists.</param>
        public static void Copy(string filePath, string destinationPath, bool overwrite = false) => File.Copy(filePath, destinationPath, overwrite);

        public static void Create(string path)
        {
            using var streamWriter = new StreamWriter(path);
            streamWriter.Close();
        }

        public static void CreateFromBase64String(string path, string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            using var fileStream = File.Create(path);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        public static async Task CreateFromBase64StringAsync(string path, string base64String)
        {
            var byteArray = Convert.FromBase64String(base64String);
            using var fileStream = File.Create(path);
            await fileStream.WriteAsync(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        public static void CreateFromBytes(string path, byte[] byteArray)
        {
            using var fileStream = File.Create(path);
            fileStream.Write(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        public static async Task CreateFromBytesAsync(string path, byte[] byteArray)
        {
            using var fileStream = File.Create(path);
            await fileStream.WriteAsync(byteArray, 0, byteArray.Length);
            fileStream.Close();
        }

        //recomendado txt, cs, html, css semelhantes
        //não utilizar doc, docx, xls, xlsx, ppt, pptx, pdf e semelhantes
        public static void CreateTextFile(string path, Encoding encoding, StringBuilder stringBuilder)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            streamWriter.Write(stringBuilder.ToString());
            streamWriter.Close();
        }

        public static void CreateTextFile(string path, Encoding encoding, string text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            streamWriter.Write(text);
            streamWriter.Close();
        }

        public static async Task CreateTextFileAsync(string path, Encoding encoding, string text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            await streamWriter.WriteAsync(text);
            streamWriter.Close();
        }

        public static void CreateTextFile(string path, Encoding encoding, string[] text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in text)
                streamWriter.WriteLine(item);

            streamWriter.Close();
        }

        public static async Task CreateTextFileAsync(string path, Encoding encoding, string[] text)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in text)
                await streamWriter.WriteLineAsync(item);

            streamWriter.Close();
        }

        /// <summary>Delete file in parameterized path.</summary>
        /// <param name="filePath">Path of the file to be deleted.</param>
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
        /// <param name="filePath">Path of the file to be moved.</param>
        /// <param name="destinationPath">Destination path of the file to be moved.</param>
        public static void Move(string filePath, string destinationPath) => File.Move(filePath, destinationPath);

        /// <summary>Opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public static byte[] ReadToBytes(string path) => File.ReadAllBytes(path);

        /// <summary>Opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        public static string ReadToBase64String(string path) => Convert.ToBase64String(File.ReadAllBytes(path));
    }
}