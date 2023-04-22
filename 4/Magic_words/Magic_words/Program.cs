using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Magic_words
{
    internal class Program
    {

        public static Dictionary<char, List<int>> inputWord(string word1, string word2, Dictionary<char, List<int>> dict)
        {
            foreach (char c in word1)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c][0]++;
                }
                else
                {
                    dict.Add(c, new List<int> { 1, 0 });
                }
            }

            foreach (char c in word2)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c][1]++;
                }
                else
                {
                    dict.Add(c, new List<int> { 0, 1 });
                }
            }

            return dict;
        }



        static void Main(string[] args)
        {
            string firstWord = Console.ReadLine();
            string secondWord = Console.ReadLine();
            Dictionary<char, List<int>> letters = new Dictionary<char, List<int>>();

            letters = inputWord(firstWord, secondWord, letters);

            int count = 0;

            foreach (char c in letters.Keys)
            {
                if (letters[c][0] != letters[c][1])
                {
                    count += Math.Abs(letters[c][0] - letters[c][1]);
                }

            }

            Console.WriteLine(count);
        }
    }
}
