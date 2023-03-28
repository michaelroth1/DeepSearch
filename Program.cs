//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using ConsoleApp1;

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Erstellen der Wortliste
//        string[] words = GenerateWords();

//        // Eingabe des Suchmusters
//        Console.Write("Suchmuster eingeben: ");
//        string searchPattern = "AA";

//        // Parallel.ForEach-Loop zur Suche
//        List<string> foundWords = new List<string>();

//        var sW = Stopwatch.StartNew();
//        Parallel.ForEach(words, (word) =>
//        {
//            if (word.StartsWith(searchPattern))
//            {
//                lock (foundWords)
//                {
//                    foundWords.Add(word);
//                }
//            }
//        });

//        sW.Stop();

//        Console.WriteLine(sW.ElapsedMilliseconds);

//        // Ausgabe der gefundenen Wörter
//        Console.WriteLine("Gefundene Wörter:");
//        foreach (string word in foundWords)
//        {
//            Console.WriteLine(word);
//        }
//    }

//    //Methode zur Generierung der Wortliste
//    static string[] GenerateWords()
//    {
//        List<string> words = new List<string>();
//        for (char a = 'A'; a <= 'Z'; a++)
//        {
//            for (char b = 'A'; b <= 'Z'; b++)
//            {
//                for (char c = 'A'; c <= 'Z'; c++)
//                {
//                    for (char d = 'A'; d <= 'Z'; d++)
//                    {
//                        string word = new string(new char[] { a, b, c, d });
//                        words.Add(word);
//                    }
//                }
//            }
//        }
//        words.Shuffle(); // Zufälliges Mischen der Wortliste
//        return words.ToArray();
//    }
//}





