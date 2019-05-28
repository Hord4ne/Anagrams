using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Anagrams
{
    class Program
    {
        /*
         * The idea is pretty simple although I had some problem with interpretation of "all the combinationsof words that are anagrams"
         * I assumed (based on example output) that we want to print only one arrangment of anagrams
         * The algorithm is as follows
         * 1. Sort each word seperatly
         * 2. Insert into Dictionary where key is sorted word, value is the list of words
         * 3. Traverse the Dictionary and print the lists (at the same time solve programming pleasure subtask, also here I assumed there is only one winner)
         * 
         */
        static void Main(string[] args)
        {
            var pathToFile = "dict.txt";
            var anagramsDict = new Dictionary<string, List<string>>();

            foreach (var line in File.ReadLines(pathToFile))
            {
                var sorted = string.Concat(line.OrderBy(x => x));
                if (!anagramsDict.ContainsKey(sorted))
                    anagramsDict[sorted] = new List<string>();
                anagramsDict[sorted].Add(line);
            }

            var maxWordsLen = 0;
            var maxSetCount = 0;
            var maxWords = new List<string>();
            var maxSet = new List<string>();

            foreach (var dictEntry in anagramsDict)
            {
                Console.WriteLine(string.Join(' ', dictEntry.Value));
                if (maxWordsLen < dictEntry.Key.Length)
                {
                    maxWordsLen = dictEntry.Key.Length;
                    maxWords = dictEntry.Value;
                }
                if (maxSetCount < dictEntry.Value.Count)
                {
                    maxSetCount = dictEntry.Value.Count;
                    maxSet = dictEntry.Value;
                }
            }
            Console.WriteLine($"Longest words that are anagrams: {string.Join(' ', maxWords)}");
            Console.WriteLine($"Longest set of anagrams: {string.Join(' ', maxSet)}");
        }
    }
}
