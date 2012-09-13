using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderReader
{
    public class Writer
    {
        public Writer(string outputPath, IEnumerable<string> files)
        {
            OutputPath = outputPath;
            Files = files;
        }

        public void Write()
        {
            var listing = GenerateListing();
            var fileName = string.Format("{0}", OutputPath);
            StreamWriter writer = new StreamWriter(fileName);
            writer.Write(listing);
            writer.Flush();
            writer.Close();
        }

        private string GenerateListing()
        {
            var sb = new StringBuilder();
            foreach(var file  in Files)
                sb.AppendLine(file);

            return sb.ToString();
        }

        public IEnumerable<string> Files { get; set; }

        public string OutputPath { get; set; }
    }
}
