using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordFinder;
using WordFinder.Trie;

namespace ConsoleTestBench
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            var loader = new FileLoader();
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            trie.InsertRange(loader.LoadFile());
            stopwatch.Stop();

            Console.WriteLine("Took {0}ms to create Trie.", stopwatch.ElapsedMilliseconds);

            stopwatch.Reset();

            stopwatch.Start();
            var containsWord = trie.Search("diazepam");
            stopwatch.Stop();
            Console.WriteLine("Took {0}ms to find the word, result: {1}", stopwatch.ElapsedMilliseconds, containsWord);

            stopwatch.Reset();

            stopwatch.Start();
            var prefixNode = trie.Prefix("diazepam");
            stopwatch.Stop();
            Console.WriteLine("Took {0}ms to find the prefix, result: {1}", stopwatch.ElapsedMilliseconds, prefixNode.Value);

            Console.ReadKey();
        }
    }
}
