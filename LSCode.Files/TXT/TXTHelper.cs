using LSCode.Files.General;
using System;
using System.IO;

namespace LSCode.Files.TXT
{
    /// <summary>Helper that assists in the manipulation of files with ".txt" extension.</summary>
    public class TXTHelper : FileHelper
    {
        /// <summary>TXTHelper class constructor.</summary>
        /// <returns>Create an instance of the TXTHelper class.</returns>
        public TXTHelper() { }

        /// <summary>Create empty file in parameterized path.</summary>
        /// <param name="filePath">Path where the file will be created.</param>
        public void CriarArquivo(string filePath)
        {
            try
            {
                var streamWriter = new StreamWriter(filePath);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Read entire file in parameterized path.</summary>
        /// <param name="filePath">Path where the file to be read.</param>
        /// <returns>File content.</returns>
        /// <exception cref="Exception">Error reading file.</exception>
        public string ReadAllText(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Read all lines from file in parameterized path.</summary>
        /// <param name="filePath">Path where the file to be read.</param>
        /// <returns>File content obtido linha a linha.</returns>
        /// <exception cref="Exception">Error reading file.</exception>
        public string[] ReadAllLines(string filePath)
        {
            try
            {
                return File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Saves the content of a string in the file, if it does not exist, it will be created in the parameterized path.</summary>
        /// <param name="filePath">Path where the file will be saved.</param>
        /// <param name="content">Content that will be saved in the file.</param>
        /// <exception cref="Exception">Error saving file.</exception>
        public void WriteAllText(string filePath, string content)
        {
            try
            {
                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Saves content of an array in the file line by line, if it does not exist, it will be created in the parameterized path.</summary>
        /// <param name="filePath">Path where the file will be saved.</param>
        /// <param name="content">Content that will be saved in the file.</param>
        /// <exception cref="Exception">Error saving file.</exception>
        public void WriteAllLines(string filePath, string[] content)
        {
            try
            {
                File.WriteAllLines(filePath, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Appends new content of a string to the end of an existing file, if it does not exist, it will be created in the parameterized path.</summary>
        /// <param name="filePath">Path where the file will be saved.</param>
        /// <param name="content">Content that will be saved in the file.</param>
        /// <exception cref="Exception">Error saving file.</exception>
        public void AppendContent(string filePath, string content)
        {
            try
            {
                using (var streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>Appends new content of an array to an existing file line by line, if it does not exist, it will be created in the parameterized path.</summary>
        /// <param name="filePath">Path where the file will be saved.</param>
        /// <param name="content">Content that will be saved in the file.</param>
        /// <exception cref="Exception">Error saving file.</exception>
        public void AppendContent(string filePath, string[] content)
        {
            try
            {
                using (var streamWriter = new StreamWriter(filePath, true))
                {
                    foreach (var line in content)
                        streamWriter.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}