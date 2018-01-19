using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    class Searcher
    {
        public int BinarySearch(string[] words, string wordToFind)
        {
            var length = words.Length;
            var split = words.Length / 2;
            var indexToCheck = length / 2;
            while (words[indexToCheck] != wordToFind)
            {
                var compared = string.Compare(words[indexToCheck], wordToFind);
                if (split > 1) { split /= 2; }
                if (compared < 0)
                {
                    indexToCheck += split;
                }
                else
                {
                    indexToCheck -= split;
                }
            }
            return indexToCheck;
        }

        public int LinearSearch(string[] words, string wordToFind)
        {
            var index = 0;
            while (words.Length > index && words[index] != wordToFind)
            {
                index++;
            }
            return index;
        }
    }
}
