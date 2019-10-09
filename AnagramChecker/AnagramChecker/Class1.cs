using System;
using System.Collections.Generic;
using System.IO;

namespace AnagramChecker
{
    public static class Class1
    {
        public static bool CheckAnagram(string first, string second)
        {
            if (first.Length != second.Length)
                return false;

            if (first == second)
                return true;//or false: Don't know whether a string counts as an anagram of itself

            Dictionary<char, int> pool = new Dictionary<char, int>();
            foreach (char element in first.ToCharArray()) //fill the dictionary with that available chars and count them up
            {
                if (pool.ContainsKey(element))
                    pool[element]++;
                else
                    pool.Add(element, 1);
            }
            foreach (char element in second.ToCharArray()) //take them out again
            {
                if (!pool.ContainsKey(element)) //if a char isn't there at all; we're out
                    return false;
                if (--pool[element] == 0) //if a count is less than zero after decrement; we're out
                    pool.Remove(element);
            }
            return pool.Count == 0;
        }

        public static List<string> FindAnagram(string findWord)
        {
            string dictionaryText;
            try
            {
                dictionaryText =  File.ReadAllText("AnagramDictionary.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ErrorOccured", ex);
                throw;
            }
            Dictionary<string, List<string>> dictionary = new Dictionary<string,List<string>>();
            string[] wordPairs=dictionaryText.Split('\n');
            foreach(string pair in wordPairs)
            {
                if(pair!=null && pair != "")
                {
                    string[] help = pair.Split('=');
                    List<string> list = new List<string>();
                    list.Add(help[1]);
                    if (dictionary.ContainsKey(help[0]))
                    {
                        dictionary[help[0]].Add(help[1]);
                    }
                    else
                    {
                        dictionary.Add(help[0], list);
                    }
                }
            }

            List<string> results = new List<string>();
            foreach(string key in dictionary.Keys)
            {
                if (findWord != null)
                {
                    if (findWord.CompareTo(key) == 0)
                    {
                        for (int i = 0; i < dictionary[key].Count; i++)
                        {
                            Console.WriteLine(dictionary[key][i]);
                            dictionary[key][i].Replace("\n", "");
                            results.Add(dictionary[key][i]);
                        }
                    }
                }
            }
            return results;
        }
    }
}
