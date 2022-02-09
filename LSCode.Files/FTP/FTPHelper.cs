using System;
using System.IO;
using System.Net;

namespace LSCode.Files.FTP
{
    /// <summary>Helper that assists in the manipulation of directories and files through FTP.</summary>
    public class FTPHelper
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

        /// <summary>Checks if a directory exists in the given path.</summary>
        /// <param name="directoryPath">Directory path to be checked.</param>
        /// <returns>True if it exists or False if it doesn't exist.</returns>
        public bool DirectoryExists(string directoryPath)
        {
            var request = (FtpWebRequest)WebRequest.Create(directoryPath);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Credentials = new NetworkCredential(User, Password);

            try
            {
                _ = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Creates directory in the parameterized path.</summary>
        /// <param name="directoryPath">Path of the directory that will be created.</param>
        /// <exception cref="Exception">Error creating directory.</exception>
        public void CreateDirectory(string directoryPath)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(directoryPath);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential(User, Password);
                _ = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Delete directory in parameterized path.</summary>
        /// <param name="directoryPath">Directory path to be deleted.</param>
        /// <exception cref="Exception">Error deleting directory.</exception>
        public void DeleteDirectory(string directoryPath)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(directoryPath);
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;
                request.Credentials = new NetworkCredential(User, Password);
                _ = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Checks if a file exists in the parameterized path.</summary>
        /// <param name="directoryPath">Directory path.</param>
        /// <param name="fileName">Name of the file to be verified.</param>
        /// <returns>True if it exists or False if it doesn't exist.</returns>
        public bool FileExists(string directoryPath, string fileName)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(directoryPath);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.Credentials = new NetworkCredential(User, Password);

                var ftpResponse = (FtpWebResponse)request.GetResponse();

                var reader = new StreamReader(ftpResponse.GetResponseStream());
                return reader.ReadToEnd().Contains(fileName);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Uploads a file of any extension to the parameterized destination.</summary>
        /// <param name="filePathToUpload">Path of the file to be sent.</param>
        /// <param name="destinationFolderPath">Directory path where the file will be uploaded.</param>
        /// <exception cref="Exception">Error uploading file.</exception>
        public void UploadFile(string filePathToUpload, string destinationFolderPath)
        {
            try
            {
                var fileStream = File.OpenRead(filePathToUpload);

                var buffer = new byte[fileStream.Length];

                fileStream.Read(buffer, 0, buffer.Length);

                var uri = new Uri(destinationFolderPath);

                var request = (FtpWebRequest)WebRequest.Create(uri);
                request.Credentials = new NetworkCredential(User, Password);
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.ContentLength = buffer.Length;

                var stream = request.GetRequestStream();
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();

                fileStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Delete file in parameterized path.</summary>
        /// <param name="filePath">Path of the file to be deleted.</param>
        /// <exception cref="Exception">Error deleting file.</exception>
        public void DeleteFile(string filePath)
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(filePath);
                request.Credentials = new NetworkCredential(User, Password);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                _ = (FtpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}