using System;
using System.Collections.Generic;
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

        /// <summary>Append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        void AppendFile(string path, string contentBase64String);

        /// <summary>Append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        void AppendFile(string path, byte[] contentByteArray);

        /// <summary>Asynchronously append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        Task AppendFileAsync(string path, string contentBase64String);

        /// <summary>Asynchronously append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        Task AppendFileAsync(string path, byte[] contentByteArray);

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

        /// <summary>Download a file from the parameterized destination.</summary>
        /// <param name="path">Path of the file to be downloaded.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be saved.</param>
        void DownloadFile(string path, string destinationFolderPath);

        /// <summary>Asynchronously download a file from the parameterized destination.</summary>
        /// <param name="path">Path of the file to be downloaded.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be saved.</param>
        Task DownloadFileAsync(string path, string destinationFolderPath);

        /// <summary>Determines whether the specified file exists.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>True if path refers to an existing file; False if the file does not exist.</returns>
        bool FileExists(string path);

        /// <summary>Asynchronously determines whether the specified file exists.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>True if path refers to an existing file; False if the file does not exist.</returns>
        Task<bool> FileExistsAsync(string path);

        /// <summary>Retrieves the size of a file in bytes.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the size of a file in bytes. If it does not exist, it returns zero.</returns>
        long GetFileSize(string path);

        /// <summary>Asynchronously retrieves the size of a file in bytes.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the size of a file in bytes. If it does not exist, it returns zero.</returns>
        Task<long> GetFileSizeAsync(string path);

        /// <summary>Retrieves the date-time stamp from a file.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the date-time stamp from a file.</returns>
        DateTime GetLastModifiedDateUTC(string path);

        /// <summary>Asynchronously retrieves the date-time stamp from a file.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the date-time stamp from a file.</returns>
        Task<DateTime> GetLastModifiedDateUTCAsync(string path);

        /// <summary>Retrieves a list of child directories and files.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>Returns a list of child directories and files.</returns>
        List<string> ListDirectoryContent(string path);

        /// <summary>Asynchronously retrieves a list of child directories and files.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>Returns a list of child directories and files.</returns>
        Task<List<string>> ListDirectoryContentAsync(string path);

        /// <summary>Renames a directory or file.</summary>
        /// <param name="path">Directory path or file path to be remaned.</param>
        /// <param name="newPath">Name for directory or file.</param>
        void Rename(string path, string newPath);

        /// <summary>Asynchronously renames a directory or file.</summary>
        /// <param name="path">Directory path or file path to be remaned.</param>
        /// <param name="newPath">Name for directory or file.</param>
        Task RenameAsync(string path, string newPath);

        /// <summary>Uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        void UploadFile(string contentBase64String, string destinationFolderPath);

        /// <summary>Uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        void UploadFile(byte[] contentByteArray, string destinationFolderPath);

        /// <summary>Asynchronously uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        Task UploadFileAsync(string contentBase64String, string destinationFolderPath);

        /// <summary>Asynchronously uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        Task UploadFileAsync(byte[] contentByteArray, string destinationFolderPath);
    }
}