using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using ConsoleApp1.Models;

    class Program
    {
        static void Main(string[] args)
        {
            // Populate the trie with all possible 4-letter combinations of uppercase letters
            TrieNode root = new TrieNode();
            for (char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        for (char c4 = 'A'; c4 <= 'Z'; c4++)
                        {
                            string word = new string(new char[] { c1, c2, c3, c4 });
                            root.Insert(word);
                        }
                    }
                }
            }

            root.Insert("TISCHLER");

            // Prompt the user for a prefix to search for
            Console.Write("Enter a prefix to search for: ");
            string prefix = "z";

            var sW = Stopwatch.StartNew();

            // Search the trie for all words that start with the prefix
            List<string> words = root.Search(prefix);

            sW.Stop();

            Console.WriteLine(sW.ElapsedMilliseconds);

            // Print the search results
            Console.WriteLine("Words starting with '{0}':", prefix);
            foreach (string word in words)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
