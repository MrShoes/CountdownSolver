using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Trie
{
    class Trie
    {
        /// <summary>
        /// Gets or sets the nodes.
        /// </summary>
        /// <value>
        /// The nodes.
        /// </value>
        public IDictionary<char, TrieNode> Nodes { get; set; }

        public Trie()
        {
            Nodes = new Dictionary<char, TrieNode>();
        }

        protected TrieNode Prefix(string s)
        {
            TrieNode node;
            if(!Nodes.ContainsKey(s[0]))
            {
                node = new TrieNode(s[0], 0, null);

            }
        }
    }
}
