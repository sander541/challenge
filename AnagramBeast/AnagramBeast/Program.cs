using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AnagramBeast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string inputString = "";
            List<string> foundAnagrams = new List<string>();

            string dictionaryPath = args[0];
            if (args.Length > 2)
            {
                inputString = string.Join(" ", args.Skip(1));
            }
            else
            {
                inputString = args[1];
            }
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            using (StreamReader sr = File.OpenText(dictionaryPath))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Length == inputString.Length)
                    {
                        if (IsAnagram(s, inputString))
                        {
                            foundAnagrams.Add(s);
                        }
                    }
                    
                }
            }

            stopWatch.Stop();
            Console.WriteLine("Output(duration, anagrams found): " + (stopWatch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L))) + "," + string.Join(", ", foundAnagrams));
        }

        public static bool IsAnagram(string firstWord, string secondWord)
        {
            char[] secondWordChars = secondWord.ToCharArray();
            char[] firstWordChars = firstWord.ToCharArray();

            Array.Sort(secondWordChars);
            Array.Sort(firstWordChars);

            for (int i = 0; i < firstWordChars.Length; i++)
            {
                if (secondWordChars[i] != firstWordChars[i])
                    return false;
            }
            return true;
        }
    }
}
