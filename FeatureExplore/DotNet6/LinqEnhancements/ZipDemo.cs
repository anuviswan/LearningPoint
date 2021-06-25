using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace LinqEnhancements
{
    public static class ZipDemo
    {
        public static void NewApproach()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };
            string[] romans = { "I", "II", "III" };

            var numbersAndWordsAndRoman = numbers.Zip(words, romans);

            foreach (var (number, word, roman) in numbersAndWordsAndRoman)
                WriteLine($"{number}-{word}-{roman}");
        }

        public static void OldApproach()
        {
            int[] numbers = { 1, 2, 3, 4 };
            string[] words = { "one", "two", "three" };
            string[] romans = { "I", "II", "III" };

            var numbersAndWords = numbers.Zip(words, (number, word) => (number, word));
            var numbersAndWordsAndRoman = numbersAndWords.Zip(romans,(numberWord,roman)=> (numberWord.number, numberWord.word,roman));

            foreach (var (number, word, roman) in numbersAndWordsAndRoman)
                WriteLine($"{number}-{word}-{roman}");
        }
    }
}
