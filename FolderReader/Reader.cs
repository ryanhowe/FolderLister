using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FolderReader
{
    public class Reader
    {
        private string _pathToRead;
        public Reader(string pathToRead)
        {
            PathToRead = pathToRead;
        }

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
