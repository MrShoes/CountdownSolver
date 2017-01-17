using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordFinder
{
    public class WordsFileCleaner
    {
        private string _fileName;

        /// <summary>
        /// The maximum word length.
        /// In this case, Countdown uses 9 letters.
        /// </summary>
        private const int MaxWordLength = 9;

        private const string RegexPattern = @"\w{1,9}";

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsFileCleaner"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public WordsFileCleaner(string filename = "words.txt")
        {
            _fileName = filename;
        }

        /// <summary>
        /// Cleans this instance.
        /// </summary>
        public void Clean()
        {
            var words = LoadFile();
            var cleanedWords = CleanOutWords(words);
        }

        /// <summary>
        /// Loads the file.
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<string> LoadFile()
        {
            var words = new List<string>();
            using (var fileStream = File.OpenRead(_fileName))
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

        /// <summary>
        /// Cleans the useless words.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> CleanOutWords(IEnumerable<string> words)
        {
            var newWords = new List<string>();
            var regex = new Regex(RegexPattern);

            foreach(var word in words)
            {
                if (regex.IsMatch(word))
                    newWords.Add(word);
            }

            return newWords;
        }
    }
}
