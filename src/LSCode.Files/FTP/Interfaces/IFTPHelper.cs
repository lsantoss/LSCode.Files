using System;
using System.Threading.Tasks;

namespace LSCode.Files.FTP.Interfaces
{
    /// <summary>Provides contract for the implementation of FTP connections, providing methods that help the manipulation of directories and files.</summary>
    public interface IFTPHelper
    {
        /// <value>User used for the connection.</value>
        public string User { get; }

        /// <value>Password used for the connection.</value>
        public string Password { get; }

        /// <summary>Creates a directory in the parameterized path.</summary>
        /// <param name="path">The directory path to be create.</param>
        void CreateDirectory(string path);

        /// <summary>Asynchronously creates a directory in the parameterized path.</summary>
        /// <param name="path">The directory path to be create.</param>
        Task CreateDirectoryAsync(string path);

        /// <summary>Deletes a directory in parameterized path.</summary>
        /// <param name="path">The directory path to be deleted.</param>
        void DeleteDirectory(string path);

        /// <summary>Asynchronously deletes a directory in parameterized path.</summary>
        /// <param name="path">The directory path to be deleted.</param>
        Task DeleteDirectoryAsync(string path);

        /// <summary>Delete file in parameterized path.</summary>
        /// <param name="path">Path of the file to be deleted.</param>
        void DeleteFile(string path);

        /// <summary>Asynchronously delete file in parameterized path.</summary>
        /// <param name="path">Path of the file to be deleted.</param>
        Task DeleteFileAsync(string path);

        /// <summary>Determines whether the given path refers to an existing directory.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; false if the directory does not exist.</returns>
        bool DirectoryExists(string path);

        /// <summary>Asynchronously determines whether the given path refers to an existing directory.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; false if the directory does not exist.</returns>
        Task<bool> DirectoryExistsAsync(string path);

        /// <summary>Determines whether the specified file exists.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>True if path refers to an existing file; False if the file does not exist.</returns>
        bool FileExists(string path);

        /// <summary>Asynchronously determines whether the specified file exists.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>True if path refers to an existing file; False if the file does not exist.</returns>
        Task<bool> FileExistsAsync(string path);

        void UploadFileFromBase64String(string base64String, string destinationFolderPath);
        void UploadFileFromBytes(byte[] byteArray, string destinationFolderPath);
        void UploadFileFromPath(string path, string destinationFolderPath);
    }
}