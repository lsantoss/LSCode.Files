using LSCode.Files.Files.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace LSCode.Files.Files
{
    /// <summary>Helper that assists in files manipulations.</summary>
    public class FileHelper : IFileHelper
    {
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

        /// <summary>Opens a binary file, reads the contents of the file into a byte array, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A byte array containing the contents of the file.</returns>
        public byte[] ReadToBytes(string path) => File.ReadAllBytes(path);

        /// <summary>Opens a binary file, reads the contents of the file into a base64string, and then closes the file.</summary>
        /// <param name="path">The file to open for reading.</param>
        /// <returns>A base64string containing the contents of the file.</returns>
        public string ReadToBase64String(string path) => Convert.ToBase64String(File.ReadAllBytes(path));
                
        public void Create(string path)
        {
            using var streamWriter = new StreamWriter(path);
            streamWriter.Close();
        }

        public void Create(string path, byte[] data)
        {
            using var fileStream = File.Create(path);
            fileStream.Write(data, 0, data.Length);
            fileStream.Close();
        }

        public async Task CreateAsync(string path, byte[] data)
        {
            using var fileStream = File.Create(path);
            await fileStream.WriteAsync(data, 0, data.Length);
            fileStream.Close();
        }

        public void Create(string path, string content, Encoding encoding)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            streamWriter.Write(content);
            streamWriter.Close();
        }

        public async Task CreateAsync(string path, string content, Encoding encoding)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);
            await streamWriter.WriteAsync(content);
            streamWriter.Close();
        }

        public void Create(string path, string[] content, Encoding encoding)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in content)
                streamWriter.WriteLine(item);

            streamWriter.Close();
        }

        public async Task CreateAsync(string path, string[] content, Encoding encoding)
        {
            using var streamWriter = new StreamWriter(path, false, encoding);

            foreach (var item in content)
                await streamWriter.WriteLineAsync(item);

            streamWriter.Close();
        }
























        /// <summary>Copy file with the possibility of overwriting if it already exists.</summary>
        /// <param name="filePath">Path of the file to be copied.</param>
        /// <param name="destinationPath">File copy destination path.</param>
        /// <param name="overwrite">Indicates whether or not to overwrite if the file exists.</param>
        public void Copy(string filePath, string destinationPath, bool overwrite = false)
        {
            try
            {
                File.Copy(filePath, destinationPath, overwrite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Move file without possibility to overwrite if it already exists.</summary>
        /// <param name="filePath">Path of the file to be moved.</param>
        /// <param name="destinationPath">Destination path of the file to be moved.</param>
        public void Move(string filePath, string destinationPath)
        {
            try
            {
                File.Move(filePath, destinationPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Delete file in parameterized path.</summary>
        /// <param name="filePath">Path of the file to be deleted.</param>
        public void Delete(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Save file in parameterized path from a byte array.</summary>
        /// <param name="fileInBytes">Byte array with file contents.</param>
        /// <param name="filePath">Path where the file will be saved.</param>
        public void Save(byte[] fileInBytes, string filePath)
        {
            try
            {
                File.WriteAllBytes(filePath, fileInBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Save file in parameterized path from a base64String.</summary>
        /// <param name="fileInBase64String">Base64String with file contents.</param>
        /// <param name="filePath">Path where the file will be saved.</param>
        public void Save(string fileInBase64String, string filePath)
        {
            try
            {
                var arquivoEmBytes = Convert.FromBase64String(fileInBase64String);
                File.WriteAllBytes(filePath, arquivoEmBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}