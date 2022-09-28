using System;
using System.IO;

namespace LSCode.Files.General
{
    /// <summary>Helper that assists in file manipulations.</summary>
    public class FileHelper
    {
        /// <summary>Constructor of the FilesHelper class.</summary>
        /// <returns>Creates an instance of the FilesHelper class.</returns>
        public FileHelper() { }

        /// <summary>Checks if a file exists in the parameterized path.</summary>
        /// <param name="filePath">Path of the file to be verified.</param>
        /// <returns>True if it exists or False if it doesn't exist.</returns>
        /// <exception cref="Exception">Error while checking if file exists.</exception>
        public bool FileExists(string filePath)
        {
            try
            {
                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Copy file with the possibility of overwriting if it already exists.</summary>
        /// <param name="filePath">Path of the file to be copied.</param>
        /// <param name="destinationPath">File copy destination path.</param>
        /// <param name="overwrite">Indicates whether or not to overwrite if the file exists.</param>
        /// <exception cref="Exception">Error copying file.</exception>
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
        /// <exception cref="Exception">Error moving file.</exception>
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
        /// <exception cref="Exception">Error deleting file.</exception>
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
        /// <exception cref="Exception">Error saving file.</exception>
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
        /// <exception cref="Exception">Error saving file.</exception>
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

        /// <summary>Get file at parameterized path in a byte array.</summary>
        /// <param name="filePath">Path of the file to be retrieved.</param>
        /// <returns>Array de bytes with file contents.</returns>
        /// <exception cref="Exception">Error getting the file.</exception>
        public byte[] GetFileInBytes(string filePath)
        {
            try
            {
                return File.ReadAllBytes(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Get file at parameterized path in a base64String.</summary>
        /// <param name="filePath">Path of the file to be retrieved.</param>
        /// <returns>Base64String with file contents.</returns>
        /// <exception cref="Exception">Error getting the file.</exception>
        public string GetFileInBase64String(string filePath)
        {
            try
            {
                var bytes = File.ReadAllBytes(filePath);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}