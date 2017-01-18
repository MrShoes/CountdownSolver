using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Trie
{
    public class Trie
    {
        private readonly TrieNode _root;

        /// <summary>
        /// Initializes a new instance of the <see cref="Trie"/> class.
        /// </summary>
        public Trie()
        {
            _root = new TrieNode('^', 0, null);
        }

        /// <summary>
        /// Finds the node at the prefix string.
        /// </summary>
        /// <param name="prefixString">The prefix string.</param>
        /// <returns>The node at the prefix string.</returns>
        public TrieNode Prefix(string prefixString)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach(var character in prefixString)
            {
                currentNode = currentNode.FindChild(character);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        /// <summary>
        /// Searches for the specified search string.
        /// </summary>
        /// <param name="searchString">The search string.</param>
        /// <returns>True if the word was found.</returns>
        public bool Search(string searchString)
        {
            var prefix = Prefix(searchString);
            return prefix.Depth == searchString.Length && prefix.FindChild('$') != null;
        }

        /// <summary>
        /// Inserts the range of words.
        /// </summary>
        /// <param name="words">The words.</param>
        public void InsertRange(IEnumerable<string> words)
        {
            foreach (var word in words)
                Insert(word);
        }

        /// <summary>
        /// Inserts the specified word.
        /// </summary>
        /// <param name="word">The word.</param>
        private void Insert(string word)
        {
            var prefix = Prefix(word);
            var current = prefix;
            for(var i = current.Depth; i < word.Length; i++)
            {
                var node = new TrieNode(word[i], current.Depth + 1, current);
                current.Children.Add(node);
                current = node;
            }

            current.Children.Add(new TrieNode('$', current.Depth + 1, current));
        }
    }
}
