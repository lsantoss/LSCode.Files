using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LSCode.Files.General
{
    /// <summary>Helper that assists in folder manipulations.</summary>
    public class DirectoryHelper
    {
        /// <summary>Constructor of the DirectoryHelper class.</summary>
        /// <returns>Create an instance of the DirectoryHelper class.</returns>
        public DirectoryHelper() { }

        /// <summary>Checks if a directory exists in the parameterized path.</summary>
        /// <param name="directoryPath">Directory path to be checked.</param>
        /// <returns>True caso exista ou False caso não exista.</returns>
        /// <exception cref="Exception">Error while checking if directory exists.</exception>
        public bool DirectoryExists(string directoryPath)
        {
            try
            {
                return Directory.Exists(directoryPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Create directory in parameterized path.</summary>
        /// <param name="directoryPath">Path where the directory to be created.</param>
        /// <exception cref="Exception">Error creating directory.</exception>
        public void Create(string directoryPath)
        {
            try
            {
                Directory.CreateDirectory(directoryPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Delete empty directory in parameterized path.</summary>
        /// <param name="directoryPath">Directory path to be deleted.</param>
        /// <param name="recursive">True to remove directories, subdirectories, and files in path; Otherwise, false.</param>
        /// <exception cref="Exception">Error deleting directory.</exception>
        public void Delete(string directoryPath, bool recursive = false)
        {
            try
            {
                Directory.Delete(directoryPath, recursive);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Move directory and all its contents in parameterized path.</summary>
        /// <remarks>Note: Destination path cannot exist.</remarks>
        /// <param name="originPath">Path of the directory to be moved.</param>
        /// <param name="destinationPath">Path to where the directory will be moved.</param>
        /// <exception cref="Exception">Error moving directory.</exception>
        public void Move(string originPath, string destinationPath)
        {
            try
            {
                Directory.Move(originPath, destinationPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Get list of child directories in parameterized path.</summary>
        /// <param name="directoryPath">Directory path.</param>
        /// <returns>List of child directory paths.</returns>
        /// <exception cref="Exception">Error getting child directories.</exception>
        public List<string> GetChildDirectories(string directoryPath)
        {
            try
            {
                return Directory.GetDirectories(directoryPath).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Get list of child files in parameterized path.</summary>
        /// <param name="directoryPath">Directory path.</param>
        /// <returns>Child file path list.</returns>
        /// <exception cref="Exception">Error getting child files.</exception>
        public List<string> GetChildFiles(string directoryPath)
        {
            try
            {
                return Directory.GetFiles(directoryPath).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Get list of child directories and files in parameterized path.</summary>
        /// <param name="directoryPath">Directory path.</param>
        /// <returns>List of paths of child directories and files.</returns>
        /// <exception cref="Exception">Error getting child directories and files.</exception>
        public List<string> GetAllChildContents(string directoryPath)
        {
            try
            {
                var content = Directory.GetDirectories(directoryPath).ToList();

                foreach (var item in Directory.GetFiles(directoryPath))
                    content.Add(item);

                return content;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Delete list of child directories in parameterized path.</summary>
        /// <param name="directoryPath">Directory path.</param>
        /// <exception cref="Exception">Error deleting child directories.</exception>
        public void DeleteChildDirectories(string directoryPath)
        {
            try
            {
                var directories = Directory.GetDirectories(directoryPath).ToList();

                foreach (var item in directories)
                    Directory.Delete(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Delete list of child files in parameterized path.</summary>
        /// <param name="directoryPath">Directory path.</param>
        /// <exception cref="Exception">Error deleting child files.</exception>
        public void DeleteChildFiles(string directoryPath)
        {
            try
            {
                var files = Directory.GetFiles(directoryPath).ToList();

                foreach (var item in files)
                    File.Delete(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Deletes list of child directories and files in the parameterized path.</summary>
        /// <param name="directoryPath"> Directory path.</param>
        /// <exception cref="Exception">Error deleting child directories and files.</exception>
        public void DeleteAllChildContents(string directoryPath)
        {
            try
            {
                var directories = Directory.GetDirectories(directoryPath).ToList();
                var files = Directory.GetFiles(directoryPath).ToList();

                foreach (var item in directories)
                    Directory.Delete(item);

                foreach (var item in files)
                    File.Delete(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}