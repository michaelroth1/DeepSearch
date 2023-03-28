using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    static class Extensions
    {
        private static readonly Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static List<string> ParallelStringMatching(TrieNode trie, string searchString)
        {
            int numCores = Environment.ProcessorCount;
            int chunkSize = searchString.Length / numCores;

            // Parallel search using multiple threads
            var query = Enumerable.Range(0, numCores)
                .AsParallel()
                .Select(i =>
                {
                    int startIndex = i * chunkSize;
                    int length = (i == numCores - 1) ? searchString.Length - startIndex : chunkSize;
                    string substring = searchString.Substring(startIndex, length);
                    return trie.Search(substring);
                })
                .ToArray();

            // Merge the results
            List<string> result = query[0].ToList();
            for (int i = 1; i < numCores; i++)
            {
                result.AddRange(query[i]);
            }
            return result;
        }
    }
}
