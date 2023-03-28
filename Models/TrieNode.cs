using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class TrieNode
    {
        private Dictionary<char, TrieNode> children;
        private bool isEndOfWord;

        public TrieNode()
        {
            children = new Dictionary<char, TrieNode>();
            isEndOfWord = false;
        }

        public void Insert(string word)
        {
            TrieNode currentNode = this;
            foreach (char c in word)
            {
                if (!currentNode.children.ContainsKey(c))
                {
                    currentNode.children.Add(c, new TrieNode());
                }
                currentNode = currentNode.children[c];
            }
            currentNode.isEndOfWord = true;
        }

        public List<string> Search(string prefix)
        {
            TrieNode currentNode = this;
            foreach (char c in prefix)
            {
                if (!currentNode.children.ContainsKey(c))
                {
                    return new List<string>();
                }
                currentNode = currentNode.children[c];
            }
            return SearchWords(currentNode, prefix);
        }

        private List<string> SearchWords(TrieNode node, string prefix)
        {
            List<string> words = new List<string>();
            if (node.isEndOfWord)
            {
                words.Add(prefix);
            }
            foreach (var pair in node.children)
            {
                char c = pair.Key;
                TrieNode child = pair.Value;
                List<string> childWords = SearchWords(child, prefix + c);
                words.AddRange(childWords);
            }
            return words;
        }
    }
}
