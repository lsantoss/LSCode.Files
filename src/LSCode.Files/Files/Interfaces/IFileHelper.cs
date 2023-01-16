using ImageMagick;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LSCode.Files.Files.Interfaces
{
    /// <summary>Provides contract for the implementation methods that help the manipulation of files.</summary>
    public interface IFileHelper
    {
        /// <summary>
        ///     Appends text to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        void AppendText(string path, Encoding encoding, string text);

        /// <summary>
        ///     Appends text to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        void AppendText(string path, Encoding encoding, IEnumerable<string> text);

        /// <summary>
        ///     Asynchronously appends text to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        Task AppendTextAsync(string path, Encoding encoding, string text);

        /// <summary>
        ///     Asynchronously appends to a file, and then closes the file. If the specified file does
        ///     not exist, this method creates a file, writes the specified text to the file,
        ///     and then closes the file.
        /// </summary>
        /// <param name="path">The file to append the text. The file is created if it doesn't already exist.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        Task AppendTextAsync(string path, Encoding encoding, IEnumerable<string> text);

        /// <summary>Compress image of the parameterized path.</summary>
        /// <remarks>Note: The original image will be replaced by the compressed image. There may be a loss of quality.</remarks>
        /// <param name="path">Path of the image to be compressed.</param>
        /// <param name="format">Image format.</param>
        /// <param name="width">Image width.</param>
        /// <param name="heigth">Image heigth.</param>
        void Compress(string path, MagickFormat format, int width, int heigth);

        /// <summary>Asynchronously compress image of the parameterized path.</summary>
        /// <remarks>Note: The original image will be replaced by the compressed image. There may be a loss of quality.</remarks>
        /// <param name="path">Path of the image to be compressed.</param>
        /// <param name="format">Image format.</param>
        /// <param name="width">Image width.</param>
        /// <param name="heigth">Image heigth.</param>
        Task CompressAsync(string path, MagickFormat format, int width, int heigth);

        /// <summary>Copy file with the possibility of overwriting if it already exists.</summary>
        /// <param name="sourcePath">The file to copy.</param>
        /// <param name="destinationPath">The path of the destination file. This cannot be a directory.</param>
        /// <param name="overwrite">Indicates whether or not to overwrite if the file exists.</param>
        void Copy(string sourcePath, string destinationPath, bool overwrite = true);

        /// <summary>Creates a empty file of any extension.</summary>
        /// <param name="path">The path of the file to create.</param>
        void Create(string path);

        /// <summary>Creates a file from a base64String.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="base64String">File content in base64String.</param>
        void CreateFromBase64String(string path, string base64String);

        /// <summary>Asynchronously creates a file from a base64String.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="base64String">File content in base64String.</param>
        Task CreateFromBase64StringAsync(string path, string base64String);

        /// <summary>Creates a file from a byte array.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="byteArray">File content in bytes.</param>
        void CreateFromBytes(string path, byte[] byteArray);

        /// <summary>Asynchronously creates a file from a byte array.</summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="byteArray">File content in bytes.</param>
        Task CreateFromBytesAsync(string path, byte[] byteArray);

        /// <summary>
        ///     Creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        void CreateTextFile(string path, Encoding encoding, string text);

        /// <summary>
        ///     Creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        void CreateTextFile(string path, Encoding encoding, IEnumerable<string> text);

        /// <summary>
        ///     Asynchronously creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        Task CreateTextFileAsync(string path, Encoding encoding, string text);

        /// <summary>
        ///     Asynchronously creates a text file that will contain the parameterized content.
        ///     Recommended extensions: .txt, .cs, .html, .css, .js, .json, .xml and similar.
        ///     Extensions not recommended: .doc, .docx, .xls, .xlsx, .ppt, .pptx, .pdf
        /// </summary>
        /// <param name="path">The path of the file to create.</param>
        /// <param name="encoding">The character encoding to use.</param>
        /// <param name="text">Text file content.</param>
        Task CreateTextFileAsync(string path, Encoding encoding, IEnumerable<string> text);

        /// <summary>Deletes the specified file.</summary>
        /// <param name="path">The path of the file to be deleted. Wildcard characters are not supported.</param>
        void Delete(string path);

        /// <summary>Decrypts the desired file, replacing the original file with the encrypted version.</summary>
        /// <param name="sourcePath">A path that describes a file to encrypt.</param>
        /// <param name="secret">Key to encrypt and decrypt the file.</param>
        void Decrypt(string sourcePath, string secret);

        /// <summary>Encrypts desired file, replacing the original file with the encrypted version.</summary>
        /// <param name="sourcePath">A path that describes a file to encrypt.</param>
        /// <param name="secret">Key to encrypt and decrypt the file.</param>
        void Encrypt(string sourcePath, string secret);

        /// <summary>Determines whether the specified file exists.</summary>
        /// <param name="path">The file to check.</param>
        /// <returns>
        ///     True if the caller has the required permissions and path contains the name of
        ///     an existing file; otherwise, false. This method also returns false if path is
        ///     null, an invalid path, or a zero-length string. If the caller does not have sufficient
        ///     permissions to read the specified file, no exception is thrown and the method
        ///     returns false regardless of the existence of path.
        /// </returns>
        bool Exists(string path);

        /// <summary>Get information from the desired file.</summary>
        /// <param name="path">File path to get your informations.</param>
        /// <returns>File informations.</returns>
        FileInfo Get(string path);

        /// <summary>Move file without possibility to overwrite if it already exists.</summary>
        /// <param name="sourcePath">The path of the file to move. Can include a relative or absolute path.</param>
        /// <param name="destinationPath">The new path and name for the file.</param>
        void Move(string sourcePath, string destinationPath);

        /// <summary>Opens a FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.</summary>
        /// <param name="path">The file to open.</param>
        /// <param name="mode">A FileMode value that specifies whether a file is created if one does not exist, and determines whether the contents of existing files are retained or overwritten.</param>
        /// <param name="access">A FileAccess value that specifies the operations that can be performed on the file.</param>
        /// <param name="share">A FileShare value specifying the type of access other threads have to the file.</param>
        /// <returns>A FileStream on the specified path, having the specified mode with read, write, or read/write access and the specified sharing option.</returns>
        FileStream Open(string path, FileMode mode, FileAccess access, FileShare share);

        /// <summary>Opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        string ReadToBase64String(string path);

        /// <summary>Asynchronously opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        Task<string> ReadToBase64StringAsync(string path);

        /// <summary>Opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        byte[] ReadToBytes(string path);

        /// <summary>Asynchronously opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        Task<byte[]> ReadToBytesAsync(string path);

        /// <summary>Opens a text file, reads all lines of the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        string[] ReadLines(string path);

        /// <summary>Asynchronously opens a text file, reads all lines of the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string array containing all lines of the file.</returns>
        Task<string[]> ReadLinesAsync(string path);

        /// <summary>Opens a text file, reads all the text in the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all the text in the file.</returns>
        string ReadText(string path);

        /// <summary>Asynchronously opens a text file, reads all the text in the file, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A string containing all the text in the file.</returns>
        Task<string> ReadTextAsync(string path);
    }
}
