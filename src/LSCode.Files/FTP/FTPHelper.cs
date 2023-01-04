using LSCode.Files.FTP.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace LSCode.Files.FTP
{
    /// <summary>Helper that assists in the manipulation of directories and files through FTP.</summary>
    public class FTPHelper : IFTPHelper
    {
        /// <value>User used for the connection.</value>
        public string User { get; private set; }

        /// <value>Password used for the connection.</value>
        public string Password { get; private set; }

        /// <summary>FTPHelper class constructor.</summary>
        /// <param name="user">User used for the connection.</param>
        /// <param name="password">Password used for the connection.</param>
        /// <returns>Create an instance of the FTPHelper class.</returns>
        public FTPHelper(string user, string password)
        {
            User = user;
            Password = password;
        }

        /// <summary>Creates a directory in the parameterized path.</summary>
        /// <param name="path">The directory path to be create.</param>
        public void CreateDirectory(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.GetResponse();
        }

        /// <summary>Asynchronously creates a directory in the parameterized path.</summary>
        /// <param name="path">The directory path to be create.</param>
        public async Task CreateDirectoryAsync(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            await request.GetResponseAsync();
        }

        /// <summary>Deletes a directory in parameterized path.</summary>
        /// <param name="path">The directory path to be deleted.</param>
        public void DeleteDirectory(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            request.GetResponse();
        }

        /// <summary>Asynchronously deletes a directory in parameterized path.</summary>
        /// <param name="path">The directory path to be deleted.</param>
        public async Task DeleteDirectoryAsync(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.RemoveDirectory;
            await request.GetResponseAsync();
        }

        /// <summary>Delete file in parameterized path.</summary>
        /// <param name="path">Path of the file to be deleted.</param>
        public void DeleteFile(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.GetResponse();
        }

        /// <summary>Asynchronously delete file in parameterized path.</summary>
        /// <param name="path">Path of the file to be deleted.</param>
        public async Task DeleteFileAsync(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            await request.GetResponseAsync();
        }

        /// <summary>Determines whether the given path refers to an existing directory.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; False if the directory does not exist.</returns>
        public bool DirectoryExists(string path)
        {
            try
            {
                var request = WebRequest.Create(path) as FtpWebRequest;
                request.Credentials = new NetworkCredential(User, Password);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Asynchronously determines whether the given path refers to an existing directory.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; False if the directory does not exist.</returns>
        public async Task<bool> DirectoryExistsAsync(string path)
        {
            try
            {
                var request = WebRequest.Create(path) as FtpWebRequest;
                request.Credentials = new NetworkCredential(User, Password);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                await request.GetResponseAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Determines whether the specified file exists.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>True if path refers to an existing file; False if the file does not exist.</returns>
        public bool FileExists(string path)
        {
            try
            {
                var request = WebRequest.Create(path) as FtpWebRequest;
                request.Credentials = new NetworkCredential(User, Password);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Asynchronously determines whether the specified file exists.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>True if path refers to an existing file; False if the file does not exist.</returns>
        public async Task<bool> FileExistsAsync(string path)
        {
            try
            {
                var request = WebRequest.Create(path) as FtpWebRequest;
                request.Credentials = new NetworkCredential(User, Password);
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                await request.GetResponseAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="filePathToUpload">Path of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        public void UploadFile(string filePathToUpload, string destinationFolderPath)
        {
            var fileStream = File.OpenRead(filePathToUpload);

            var buffer = new byte[fileStream.Length];

            fileStream.Read(buffer, 0, buffer.Length);

            //var uri = new Uri(destinationFolderPath);

            var request = WebRequest.Create(destinationFolderPath) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.ContentLength = buffer.Length;
            request.KeepAlive = false;
            request.UseBinary = true;

            var stream = request.GetRequestStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();

            fileStream.Close();
        }
    }
}