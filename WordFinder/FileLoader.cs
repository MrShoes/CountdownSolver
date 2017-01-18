using System;
using System.Collections.Generic;
using System.IO;

namespace WordFinder
{
    public class FileLoader
    {
        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileLoader"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public FileLoader(string fileName = "words.txt")
        {
            FileName = fileName;
        }

        /// <summary>
        /// Loads the file.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> LoadFile()
        {
            var words = new List<string>();
            using (var fileStream = File.OpenRead(FileName))
            using (var reader = new StreamReader(fileStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!String.IsNullOrEmpty(line))
                    {
                        words.Add(line);
                    }
                }
            }
            return words;
        }
    }
}
