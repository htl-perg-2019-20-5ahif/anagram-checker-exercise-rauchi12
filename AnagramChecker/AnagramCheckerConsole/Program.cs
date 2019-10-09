using System;
using System.Collections.Generic;
using AnagramChecker;

namespace AnagramCheckerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0].Contains("getKnown"))
            {
                List<string> list = AnagramChecker.Class1.FindAnagram(args[1]);
                foreach (string word in list)
                {
                    Console.WriteLine(word);
                }
            }
            if (args[0].Contains("check") && AnagramChecker.Class1.CheckAnagram(args[1], args[2]))
            {
                Console.WriteLine("Is an Anagram");
            }
        }
    }
}
