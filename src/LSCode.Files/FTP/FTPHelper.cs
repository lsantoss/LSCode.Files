using LSCode.Files.FTP.Interfaces;
using System;
using System.Collections.Generic;
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

        /// <summary>Append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        public void AppendFile(string path, string contentBase64String)
        {
            var contentByteArray = Convert.FromBase64String(contentBase64String);

            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.AppendFile;
            request.ContentLength = contentByteArray.Length;

            var requestStream = request.GetRequestStream();
            requestStream.Write(contentByteArray, 0, contentByteArray.Length);
            requestStream.Close();

            using var response = request.GetResponse() as FtpWebResponse;
            response.Close();
        }

        /// <summary>Append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        public void AppendFile(string path, byte[] contentByteArray)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.AppendFile;
            request.ContentLength = contentByteArray.Length;

            using var requestStream = request.GetRequestStream();
            requestStream.Write(contentByteArray, 0, contentByteArray.Length);
            requestStream.Close();

            using var response = request.GetResponse() as FtpWebResponse;
            response.Close();
        }

        /// <summary>Asynchronously append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        public async Task AppendFileAsync(string path, string contentBase64String)
        {
            var contentByteArray = Convert.FromBase64String(contentBase64String);

            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.AppendFile;
            request.ContentLength = contentByteArray.Length;

            using var requestStream = await request.GetRequestStreamAsync();
            await requestStream.WriteAsync(contentByteArray, 0, contentByteArray.Length);
            requestStream.Close();

            using var response = await request.GetResponseAsync() as FtpWebResponse;
            response.Close();
        }

        /// <summary>Asynchronously append a file to an existing file in the parameterized path, if the file does not exist it will be created.</summary>
        /// <param name="path">The file path to be appended.</param>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        public async Task AppendFileAsync(string path, byte[] contentByteArray)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.AppendFile;
            request.ContentLength = contentByteArray.Length;

            using var requestStream = await request.GetRequestStreamAsync();
            await requestStream.WriteAsync(contentByteArray, 0, contentByteArray.Length);
            requestStream.Close();

            using var response = await request.GetResponseAsync() as FtpWebResponse;
            response.Close();
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

        /// <summary>Download a file from the parameterized destination.</summary>
        /// <param name="path">Path of the file to be downloaded.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be saved.</param>
        public void DownloadFile(string path, string destinationFolderPath)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            using var stream = request.GetResponse().GetResponseStream();
            using var fileStream = File.Create(destinationFolderPath);
            stream.CopyTo(fileStream);
        }

        /// <summary>Asynchronously download a file from the parameterized destination.</summary>
        /// <param name="path">Path of the file to be downloaded.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be saved.</param>
        public async Task DownloadFileAsync(string path, string destinationFolderPath)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            using var stream = (await request.GetResponseAsync()).GetResponseStream();
            using var fileStream = File.Create(destinationFolderPath);
            await stream.CopyToAsync(fileStream);
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

        /// <summary>Retrieves the size of a file in bytes.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the size of a file in bytes. If it does not exist, it returns zero.</returns>
        public long GetFileSize(string path)
        {
            try
            {
                var request = WebRequest.Create(path) as FtpWebRequest;
                request.Credentials = new NetworkCredential(User, Password);
                request.Method = WebRequestMethods.Ftp.GetFileSize;

                using var response = request.GetResponse() as FtpWebResponse;
                return response.ContentLength;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>Asynchronously retrieves the size of a file in bytes.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the size of a file in bytes. If it does not exist, it returns zero.</returns>
        public async Task<long> GetFileSizeAsync(string path)
        {
            try
            {
                var request = WebRequest.Create(path) as FtpWebRequest;
                request.Credentials = new NetworkCredential(User, Password);
                request.Method = WebRequestMethods.Ftp.GetFileSize;

                using var response = await request.GetResponseAsync() as FtpWebResponse;
                return response.ContentLength;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>Retrieves the date-time stamp from a file.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the date-time stamp from a file.</returns>
        public DateTime GetLastModifiedDateUTC(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            using var response = request.GetResponse() as FtpWebResponse;
            return response.LastModified.ToUniversalTime();
        }

        /// <summary>Asynchronously retrieves the date-time stamp from a file.</summary>
        /// <param name="path">File path to be checked.</param>
        /// <returns>Returns the date-time stamp from a file.</returns>
        public async Task<DateTime> GetLastModifiedDateUTCAsync(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            using var response = await request.GetResponseAsync() as FtpWebResponse;
            return response.LastModified.ToUniversalTime();
        }

        /// <summary>Retrieves a list of child directories and files.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>Returns a list of child directories and files.</returns>
        public List<string> ListDirectoryContent(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            using var response = request.GetResponse() as FtpWebResponse;

            using var streamReader = new StreamReader(response.GetResponseStream());

            var directories = new List<string>();

            var line = streamReader.ReadLine();

            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }

            streamReader.Close();

            response.Close();

            return directories;
        }

        /// <summary>Asynchronously retrieves a list of child directories and files.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>Returns a list of child directories and files.</returns>
        public async Task<List<string>> ListDirectoryContentAsync(string path)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            using var response = await request.GetResponseAsync() as FtpWebResponse;

            using var streamReader = new StreamReader(response.GetResponseStream());

            var directories = new List<string>();

            var line = await streamReader.ReadLineAsync();

            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = await streamReader.ReadLineAsync();
            }

            streamReader.Close();

            response.Close();

            return directories;
        }

        /// <summary>Renames a directory or file.</summary>
        /// <param name="path">Directory path or file path to be remaned.</param>
        /// <param name="newPath">Name for directory or file.</param>
        public void Rename(string path, string newPath)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = newPath;
            request.UseBinary = true;

            using var response = request.GetResponse() as FtpWebResponse;

            using var stream = response.GetResponseStream();
            stream.Close();

            response.Close();
        }

        /// <summary>Asynchronously renames a directory or file.</summary>
        /// <param name="path">Directory path or file path to be remaned.</param>
        /// <param name="newPath">Name for directory or file.</param>
        public async Task RenameAsync(string path, string newPath)
        {
            var request = WebRequest.Create(path) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = newPath;
            request.UseBinary = true;

            using var response = await request.GetResponseAsync() as FtpWebResponse;

            using var stream = response.GetResponseStream();
            stream.Close();

            response.Close();
        }

        /// <summary>Uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        public void UploadFile(string contentBase64String, string destinationFolderPath)
        {
            var contentByteArray = Convert.FromBase64String(contentBase64String);

            var request = WebRequest.Create(destinationFolderPath) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.ContentLength = contentByteArray.Length;
            request.KeepAlive = false;
            request.UseBinary = true;

            using var stream = request.GetRequestStream();
            stream.Write(contentByteArray, 0, contentByteArray.Length);
            stream.Close();
        }

        /// <summary>Uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        public void UploadFile(byte[] contentByteArray, string destinationFolderPath)
        {
            var request = WebRequest.Create(destinationFolderPath) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.ContentLength = contentByteArray.Length;
            request.KeepAlive = false;
            request.UseBinary = true;

            using var stream = request.GetRequestStream();
            stream.Write(contentByteArray, 0, contentByteArray.Length);
            stream.Close();
        }

        /// <summary>Asynchronously uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentBase64String">Content in base64String of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        public async Task UploadFileAsync(string contentBase64String, string destinationFolderPath)
        {
            var contentByteArray = Convert.FromBase64String(contentBase64String);

            var request = WebRequest.Create(destinationFolderPath) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.ContentLength = contentByteArray.Length;
            request.KeepAlive = false;
            request.UseBinary = true;

            using var stream = await request.GetRequestStreamAsync();
            await stream.WriteAsync(contentByteArray, 0, contentByteArray.Length);
            stream.Close();
        }

        /// <summary>Asynchronously uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="contentByteArray">Content in bytes of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        public async Task UploadFileAsync(byte[] contentByteArray, string destinationFolderPath)
        {
            var request = WebRequest.Create(destinationFolderPath) as FtpWebRequest;
            request.Credentials = new NetworkCredential(User, Password);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.ContentLength = contentByteArray.Length;
            request.KeepAlive = false;
            request.UseBinary = true;

            using var stream = await request.GetRequestStreamAsync();
            await stream.WriteAsync(contentByteArray, 0, contentByteArray.Length);
            stream.Close();
        }
    }
}