using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordFinder;

namespace ConsoleTestBench
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsFileCleaner = new WordsFileCleaner();
            wordsFileCleaner.Clean();

            Console.ReadKey();
        }
    }
}
