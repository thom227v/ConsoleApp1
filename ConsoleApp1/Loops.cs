using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Loops
    {

        public static int TheBiggestNumber(int[] arr)
        {
            return arr.Max();
        }

        public static int Two7sNextToEachOther(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == 7 && arr[i + 1] == 7)
                    count++;
            }
            return count;
        }

        public static bool ThreeIncreasingAdjacent(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > 2 && arr[i - 2] + 2 == arr[i] && arr[i - 1] + 1 == arr[i])
                {
                    return true;
                }
            }
            return false;
        }

        public static int[] SieveOfEratosthenes(int num)
        {
            List<int> list = new List<int>();

            list.Add(2);

            var boundary = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i <= num; i += 2)
            {
                if (IsPrime(i))
                {
                    list.Add(i);
                }
            }

            int[] arr = list.ToArray();
            return arr;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }

        public static string ExtractString(string text)
        {
            Regex regex = new Regex(@"(?<=##)[A-z\-]+(?=##)");

            var match = regex.Matches(text);

            string res = string.Join(";", match.Cast<Match>().Select(x => x.Value.Replace("<", "").Replace(">", "")).ToArray());

            if (string.IsNullOrWhiteSpace(res))
                return "empty string";

            return res;
        }

        //public static string FullSequenceOfLetters(string text)
        //{
        //    Regex regex = new Regex(@"[A-z]");
        //    string value = "";

        //    bool validate = regex.IsMatch(text);

        //    if (validate)
        //    {
        //        Console.WriteLine(text);
        //    }

        //    return value;
        //}


        public static string SumAndAverage(int first, int second)
        {
            int count = 0;
            int sum = 0;


            for (int i = first; i <= second; i++)
            {
                sum += i;
                ++count;
            }

            double average = (double)sum / count;

            return $"Sum: {sum}, Average: {average}";
        }

        //public static string DrawTriangle()
        //{
        //    string text = "*";
        //    string temp = "";
        //    int count = 0;
        //    int layers = 10;

        //    while(count < layers)
        //    {
        //        temp += text + new string('*', count) + "\n";

        //        count++;
        //    }

        //    Console.WriteLine(temp.PadLeft(5));



        //    //for (int i = 0; i < 10; i++)
        //    //{
        //    //    temp = text + new string('*', i);

        //    //    Console.WriteLine(temp);
        //    //}

        //    Console.ReadLine();
        //    return temp;


        //    //         *
        //    //        ***
        //    //       *****
        //    //      *******
        //    //     *********
        //    //    ***********
        //    //   *************
        //    //  ***************
        //    // *****************
        //    //*******************
        //}


        public static double ToThePowerOf(int num, int raised)
        {
            return Math.Pow(num, raised);
        }
    }
}