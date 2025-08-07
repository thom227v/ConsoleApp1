using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Strings
    {
        public static string AddSeparator(string text, string seperator)
        {
            string tempString = "";

            foreach (char c in text)
            {
                tempString += c + seperator;
            }

            return tempString;
        }

        public static bool IsPalindrome(string item)
        {
            if (item[0] == item[^1])
                return true;

            return false;
        }

        public static int LengthOfAString(string item)
        {
            return item.Length;
        }

        public static string StringInReverseOrder(string text)
        {
            char[] chars = text.ToCharArray();
            string temp = "";

            Array.Reverse(chars);

            foreach (char item in chars)
            {
                temp += item;
            }

            return temp;
        }

        public static int NumberOfWords(string text)
        {
            string[] strings = text.Split(' ');

            return strings.Length;
        }

        public static string RevertWordsOrder(string text)
        {
            string[] strings = text.Split(' ');
            string newString = "";

            Array.Reverse(strings);

            foreach (string item in strings)
            {
                newString += item + ' ';
            }

            return newString;
        }

        public static int HowManyOccurrences(string text, string occurrence)
        {
            string[] strings = text.Split(' ');
            int count = 0;

            foreach (string item in strings)
            {
                if (item.Equals(occurrence))
                    count++;
            }

            return count;
        }

        public static string SortCharactersDescending(string text)
        {
            string newString = "";
            IEnumerable<char> chars = text.ToCharArray().ToList().OrderDescending();

            foreach (char item in chars)
            {
                newString += item;
            }
            return newString;
        }

        public static string CompressString(string text)
        {
            string[] arr = text
                .Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                .Trim()
                .Split(' ');

            string newString = "";

            foreach (string item in arr)
            {
                newString += item[0] + item.Length.ToString();
            }

            return newString;
        }

    }
}
