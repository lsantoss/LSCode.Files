using LSCode.Files.Directories.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LSCode.Files.Directories
{
    /// <summary>Provides the implementation methods that help the manipulation of directories.</summary>
    public class DirectoryHelper : IDirectoryHelper
    {
        /// <summary>Creates directory in parameterized path.</summary>
        /// <param name="path">The directory path to create.</param>
        /// <returns>An object that represents the directory at the specified path. This object is returned regardless of whether a directory at the specified path already exists.</returns>
        public DirectoryInfo Create(string path) => Directory.CreateDirectory(path);

        /// <summary>Deletes the specified directory and any subdirectories and files in the directory.</summary>
        /// <param name="path">Directory path to be excluded.</param>
        public void Delete(string path) => Directory.Delete(path, true);

        /// <summary>Determines whether the given path refers to an existing directory on disk.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.</returns>
        public bool Exists(string path) => Directory.Exists(path);

        /// <summary>Get information from the desired directory.</summary>
        /// <param name="path">Directory path to get.</param>
        /// <returns>Returns the information of the desired directory.</returns>
        public DirectoryInfo Get(string path) => new DirectoryInfo(path);

        /// <summary>Gets an list of directory information and files information.</summary>
        /// <param name="path">Directory path.</param>
        /// <returns>List of sub directories and files.</returns>
        public List<FileSystemInfo> GetContent(string path) => new DirectoryInfo(path).GetFileSystemInfos().OrderBy(x => x.Attributes).ThenBy(x => x.Name).ToList();

        /// <summary>Gets the current working directory of the application.</summary>
        /// <returns>A string that contains the absolute path of the current working directory, and does not end with a backslash (\).</returns>
        public string GetCurrentDirectory() => Directory.GetCurrentDirectory();

        /// <summary>Gets an list of directory information.</summary>
        /// <param name="path">Directory path to get your sub directories.</param>
        /// <returns>An list of sub directories.</returns>
        public List<DirectoryInfo> GetDirectories(string path) => new DirectoryInfo(path).GetDirectories().ToList();

        /// <summary>Returns the volume information, root information, or both for the specified path.</summary>
        /// <param name="path">The path of a directory.</param>
        /// <returns>A string that contains the volume information, root information, or both for the specified path.</returns>
        public string GetDirectoryRoot(string path) => Directory.GetDirectoryRoot(path);

        /// <summary>Gets an list of files information.</summary>
        /// <param name="path">Directory path to get your files.</param>
        /// <returns>An list of files.</returns>
        public List<FileInfo> GetFiles(string path) => new DirectoryInfo(path).GetFiles().ToList();

        /// <summary>Retrieves the names of the logical drives on this computer in the form drive letter:\.</summary>
        /// <returns>The logical drives on this computer.</returns>
        public List<string> GetLogicalDrives() => Directory.GetLogicalDrives().ToList();

        /// <summary>Retrieves the parent directory of the specified path, including both absolute and relative paths.</summary>
        /// <param name="path">The path for which to retrieve the parent directory.</param>
        /// <returns>The parent directory, or null if path is the root directory, including the root of a UNC server or share name.</returns>
        public DirectoryInfo GetParent(string path) => Directory.GetParent(path);

        /// <summary>Moves a directory and its contents to a new location.</summary>
        /// <remarks>Note: The target path cannot exist.</remarks>
        /// <param name="sourcePath">The path of the directory to move.</param>
        /// <param name="destinationPath">The path to the new location for sourcePath.</param>
        public void Move(string sourcePath, string destinationPath) => Directory.Move(sourcePath, destinationPath);
    }
}