using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FolderReaderWriter
{
    /// <summary>
    /// Read the contents of a folder and collect list of all files
    /// </summary>
    public class Reader
    {
        private string _pathToRead;
        /// <summary>
        /// Initializes a new instance of the <see cref="Reader" /> class.
        /// </summary>
        /// <param name="pathToRead">The path to read.</param>
        public Reader(string pathToRead)
        {
            PathToRead = pathToRead;
        }

        /// <summary>
        /// Gets or sets the path to read.
        /// </summary>
        /// <value>
        /// The path to read.
        /// </value>
        /// <exception cref="System.ApplicationException"></exception>
        public string PathToRead 
        {
            get
            {
                return _pathToRead;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ApplicationException("PathToRead can not be null or empty");

                _pathToRead = value;
            }
        }

        /// <summary>
        /// Reads the files.
        /// </summary>
        /// <returns></returns>
        public List<string> ReadFiles()
        {           
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(PathToRead).Select(f => Path.GetFileName(f)));
            for (int i = 0; i < files.Count; i++)
            {
                
            }
            return files;
        }

        
    }
}
