using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        public void Run()
        {
            var words = LoadWords();
            var numWords = words.Length;
            var random = new Random();
            var searcher = new Searcher();
            var timer = new Stopwatch();
            timer.Start();
            for (int i = 0; i < 10000; i++)
            {
                var wordToFind = words[random.Next(numWords)];
                searcher.LinearSearch(words, wordToFind);
            }
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds / 1000);

            timer.Restart();
            for (int i = 0; i < 10000; i++)
            {
                var wordToFind = words[random.Next(numWords)];
                searcher.BinarySearch(words, wordToFind);
            }
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds / 1000);
        }

        public string[] LoadWords()
        {
            var path = "Resources/Words.txt";
            var lines = new List<string>();
            using (var sr = new StreamReader(path))
            {
                var line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            lines.Sort();
            return lines.ToArray();
        }
    }
}
