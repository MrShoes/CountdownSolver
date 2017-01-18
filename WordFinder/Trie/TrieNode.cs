using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Trie
{
    public class TrieNode
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public char Value { get; set; }

        /// <summary>
        /// Gets or sets the parent node.
        /// </summary>
        /// <value>
        /// The parent node.
        /// </value>
        public TrieNode Parent { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        public IList<TrieNode> Children { get; set; }

        /// <summary>
        /// Gets or sets the depth.
        /// </summary>
        /// <value>
        /// The depth.
        /// </value>
        public int Depth { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is a leaf.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is a leaf; otherwise, <c>false</c>.
        /// </value>
        public bool IsLeaf { get { return Children.Count == 0; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrieNode"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="parent">The parent.</param>
        public TrieNode(char value, int depth, TrieNode parent)
        {
            Value = value;
            Depth = depth;
            Parent = parent;
            Children = new List<TrieNode>();
        }

        /// <summary>
        /// Finds the child.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public TrieNode FindChild(char value)
        {
            return Children.FirstOrDefault(n => n.Value == value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
