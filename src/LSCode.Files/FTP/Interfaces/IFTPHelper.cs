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

        /// <summary>Determines whether the given path refers to an existing directory.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; false if the directory does not exist.</returns>
        bool DirectoryExists(string path);

        /// <summary>Asynchronously determines whether the given path refers to an existing directory.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; false if the directory does not exist.</returns>
        Task<bool> DirectoryExistsAsync(string path);

        /// <summary>Creates a directory in the parameterized path.</summary>
        /// <param name="path">The directory path to be create.</param>
        public void CreateDirectory(string path);

        /// <summary>Asynchronously creates a directory in the parameterized path.</summary>
        /// <param name="path">The directory path to be create.</param>
        Task CreateDirectoryAsync(string path);

        /// <summary>Deletes a directory in parameterized path.</summary>
        /// <param name="path">The directory path to be deleted.</param>
        public void DeleteDirectory(string path);

        /// <summary>Asynchronously deletes a directory in parameterized path.</summary>
        /// <param name="path">The directory path to be deleted.</param>
        Task DeleteDirectoryAsync(string path);
    }
}