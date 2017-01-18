using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordFinder
{
    public class WordsFileCleaner
    {
        private FileLoader _loader;
        /// <summary>
        /// The maximum word length.
        /// In this case, Countdown uses 9 letters.
        /// </summary>
        private const int MaxWordLength = 9;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsFileCleaner"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public WordsFileCleaner(FileLoader loader)
        {
            _loader = loader;
        }

        /// <summary>
        /// Cleans this instance.
        /// </summary>
        public void Clean()
        {
            var words = _loader.LoadFile();
            var cleanedWords = CleanOutWords(words);
            UpdateFile(cleanedWords);
        }

        /// <summary>
        /// Cleans the useless words.
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<string> CleanOutWords(IEnumerable<string> words)
        {
            var newWords = new List<string>();

            foreach (var word in words)
            {
                if (!HasSpecialChars(word))
                    newWords.Add(word);
            }

            return newWords;
        }

        /// <summary>
        /// Updates the file.
        /// </summary>
        /// <param name="words">The words.</param>
        protected void UpdateFile(IEnumerable<string> words)
        {
            using (var fileStream = File.OpenWrite(_loader.FileName))
            using (var writer = new StreamWriter(fileStream))
            {
                foreach(var word in words)
                {
                    writer.WriteLine(word);
                }
            }
        }

        /// <summary>
        /// Determines whether the string has special characters
        /// </summary>
        /// <param name="yourString">Your string.</param>
        /// <returns></returns>
        private bool HasSpecialChars(string yourString)
        {
            return yourString.Any(ch => !Char.IsLetter(ch));
        }


    }
}
