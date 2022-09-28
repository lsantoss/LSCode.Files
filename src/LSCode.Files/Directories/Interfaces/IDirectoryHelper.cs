using System.Collections.Generic;
using System.IO;

namespace LSCode.Files.Directories.Interfaces
{
    /// <summary>Provides contract for implementing directory manipulation helper.</summary>
    public interface IDirectoryHelper
    {
        /// <summary>Determines whether the given path refers to an existing directory on disk.</summary>
        /// <param name="path">Directory path to be checked.</param>
        /// <returns>True if path refers to an existing directory; false if the directory does not exist or an error occurs when trying to determine if the specified directory exists.</returns>
        bool Exists(string path);

        /// <summary>Get information from the desired directory.</summary>
        /// <param name="path">Directory path to get.</param>
        /// <returns>Returns the information of the desired directory.</returns>
        DirectoryInfo Get(string path);

        /// <summary>Creates all directories and subdirectories in the specified path unless they already exist.</summary>
        /// <param name="path">Path where the directory to be created.</param>
        /// <returns>An object that represents the directory at the specified path. This object is returned regardless of whether a directory at the specified path already exists.</returns>
        DirectoryInfo Create(string path);

        /// <summary>Deletes the specified directory and any subdirectories and files in the directory.</summary>
        /// <param name="path">Directory path to be excluded.</param>
        void Delete(string path);

        /// <summary>Moves a directory and its contents to a new location.</summary>
        /// <remarks>Note: The target path cannot exist.</remarks>
        /// <param name="sourcePath">The path of the directory to move.</param>
        /// <param name="destinationPath">The path to the new location for sourcePath.</param>
        void Move(string sourcePath, string destinationPath);

        /// <summary>Retrieves the parent directory of the specified path, including both absolute and relative paths.</summary>
        /// <param name="path">The path for which to retrieve the parent directory.</param>
        /// <returns>The parent directory, or null if path is the root directory, including the root of a UNC server or share name.</returns>
        DirectoryInfo GetParent(string path);

        /// <summary>Gets an list of directory information.</summary>
        /// <param name="path">Directory path to get your sub directories.</param>
        /// <returns>An list of sub directories.</returns>
        List<DirectoryInfo> GetDirectories(string path);

        /// <summary>Gets an list of files information.</summary>
        /// <param name="path">Directory path to get your files.</param>
        /// <returns>An list of files.</returns>
        List<FileInfo> GetFiles(string path);

        /// <summary>Gets an list of directory information and files information.</summary>
        /// <param name="path">Directory path.</param>
        /// <returns>List of sub directories and files.</returns>
        List<FileSystemInfo> GetContent(string path);

        /// <summary>Gets the current working directory of the application.</summary>
        /// <returns>A string that contains the absolute path of the current working directory, and does not end with a backslash (\).</returns>
        string GetCurrentDirectory();

        /// <summary>Returns the volume information, root information, or both for the specified path.</summary>
        /// <param name="path">The path of a directory.</param>
        /// <returns>A string that contains the volume information, root information, or both for the specified path.</returns>
        string GetDirectoryRoot(string path);

        /// <summary>Retrieves the names of the logical drives on this computer in the form drive letter:\.</summary>
        /// <returns>The logical drives on this computer.</returns>
        List<string> GetLogicalDrives();
    }
}