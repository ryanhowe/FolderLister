using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderReaderWriter
{
    /// <summary>
    /// Write the files names to file
    /// </summary>
    public class Writer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Writer" /> class.
        /// </summary>
        /// <param name="outputPath">The output path.</param>
        /// <param name="files">The files to list.</param>
        public Writer(string outputPath, IEnumerable<string> files)
        {
            OutputPath = outputPath;
            Files = files;
        }

        /// <summary>
        /// Create file
        /// </summary>
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

        /// <summary>
        /// Gets or sets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public IEnumerable<string> Files { get; set; }

        /// <summary>
        /// Gets or sets the output path.
        /// </summary>
        /// <value>
        /// The output path.
        /// </value>
        public string OutputPath { get; set; }
    }
}
