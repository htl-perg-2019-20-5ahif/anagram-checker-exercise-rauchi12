using System;
using System.Collections.Generic;
using AnagramChecker;

namespace AnagramCheckerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            string[] input = command.Split();
            if (input[0].Contains("AnagramChecker"))
            {
                if (input[1].Contains("getKnown") && input.Length==3)
                {
                    List<string> list=AnagramChecker.Class1.FindAnagram(input[2]);
                    foreach(string word in list)
                    {
                        Console.WriteLine(word);
                    }
                }
                if (input[1].Contains("check") && input.Length == 4 && AnagramChecker.Class1.CheckAnagram(input[2], input[3]))
                {
                    Console.WriteLine("Is an Anagram");   
                }
            }
        }
    }
}
