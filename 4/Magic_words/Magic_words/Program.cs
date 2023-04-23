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
        /*
         This function initializes the dictionary with the letters in the words.
         */
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
            /*
            The main idea is to create a dictionary where the key is a letter and we have list of integers where we keep the number of 
            occurances of the letter in each word. If we have two words the first will be at indx 0 and the second at indx 1.
            If we want to cpmpare more words we can easily extend the solution.

             */

            letters = inputWord(firstWord, secondWord, letters);

            int count = 0;

            foreach (char c in letters.Keys)
            {
                if (letters[c][0] != letters[c][1])
                {
                    count += Math.Abs(letters[c][0] - letters[c][1]);
                    /*
                     To find out how many letters we will remove we will caclulate the difference between the occurances of a letter in each word.
                     */
                }

            }

            Console.WriteLine(count);
        }
    }
}
