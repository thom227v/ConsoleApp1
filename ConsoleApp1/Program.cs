using System.Numerics;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(AddAndMultiply(2, 4, 5));
            //Console.WriteLine(CtoF(0));
            //Console.WriteLine(CtoF(100));
            //Console.WriteLine(CtoF(-300));
            //Console.WriteLine(ElementaryOperations(3, 8));
            //Console.WriteLine(IsResultTheSame(2 + 2, 2 * 2));
            //Console.WriteLine(IsResultTheSame(9 / 3, 16 - 1));
            //Console.WriteLine(ModuloOperations(8, 5, 2));
            //Console.WriteLine(CubeOf(2));
            //Console.WriteLine(CubeOf(-5.5));
            //Console.WriteLine(SwapTwoNumbers(87, 45));
            //Console.WriteLine(SwapTwoNumbers(-13, 2));
            //Console.WriteLine(AbsoluteValue(6832));
            //Console.WriteLine(AbsoluteValue(-392));
            //Console.WriteLine(DivisibleBy2Or3(15, 30));
            //Console.WriteLine(DivisibleBy2Or3(2, 90));
            //Console.WriteLine(DivisibleBy2Or3(7, 12));
            //Console.WriteLine(IfConsistsOfUppercaseLetters("xyz"));
            //Console.WriteLine(IfConsistsOfUppercaseLetters("DOG"));
            //Console.WriteLine(IfConsistsOfUppercaseLetters("L9#"));
            //Console.WriteLine(IfGreaterThanThirdOne([2, 7, 12]));
            //Console.WriteLine(IfGreaterThanThirdOne([-5, -8, 50]));
            //Console.WriteLine(IfNumberIsEven(721));
            //Console.WriteLine(IfNumberIsEven(1248));
            //Console.WriteLine(IfSortedAscending([3, 7, 10]));
            //Console.WriteLine(IfSortedAscending([74, 62, 99]));
            //Console.WriteLine(PositiveNegativeOrZero(5.24));
            //Console.WriteLine(PositiveNegativeOrZero(0.0));
            //Console.WriteLine(PositiveNegativeOrZero(-994.53));
            //Console.WriteLine(IfYearIsLeap(2016));
            //Console.WriteLine(IfYearIsLeap(2018));
            //Console.WriteLine(NumberTable());
            //Console.WriteLine(Loops.TheBiggestNumber([190, 291, 145, 209, 280, 200]));
            //Console.WriteLine(Loops.TheBiggestNumber([-9, -2, -7, -8, -4]));
            //Console.WriteLine(Loops.Two7sNextToEachOther([8, 2, 5, 7, 9, 0, 7, 7, 3, 1]));
            //Console.WriteLine(Loops.Two7sNextToEachOther([9, 4, 5, 3, 7, 7, 7, 3, 2, 5, 7, 7]));
            //Console.WriteLine(Loops.ThreeIncreasingAdjacent([45, 23, 44, 68, 65, 70, 80, 81, 82]));
            //Console.WriteLine(Loops.ThreeIncreasingAdjacent([7, 3, 5, 8, 9, 3, 1, 4]));
            //int[] arr = Loops.SieveOfEratosthenes(30);
            //foreach (int num in arr)
            //{
            //    Console.WriteLine(num + ", ");
            //}
            //Console.WriteLine(Loops.ExtractString("##abc##def"));
            //Console.WriteLine(Loops.ExtractString("12####78"));
            //Console.WriteLine(Loops.ExtractString("gar##d#en"));
            //Console.WriteLine(Loops.ExtractString("++##--##++"));
            ////Console.WriteLine(Loops.FullSequenceOfLetters("ds"));
            ////Console.WriteLine(Loops.FullSequenceOfLetters("or"));
            //Console.WriteLine(Loops.SumAndAverage(11, 66));
            //Console.WriteLine(Loops.SumAndAverage(-10, 0));
            ////Console.WriteLine(Loops.DrawTriangle());
            //Console.WriteLine(Loops.ToThePowerOf(-2, 3));
            //Console.WriteLine(Loops.ToThePowerOf(5, 5));
            //Console.WriteLine(Strings.AddSeparator("ABCD", "^"));
            //Console.WriteLine(Strings.AddSeparator("chocolate", "-"));
            //Console.WriteLine(Strings.IsPalindrome("eye"));
            //Console.WriteLine(Strings.IsPalindrome("home"));
            //Console.WriteLine(Strings.LengthOfAString("computer"));
            //Console.WriteLine(Strings.LengthOfAString("ice cream"));
            //Console.WriteLine(Strings.StringInReverseOrder("qwerty"));
            //Console.WriteLine(Strings.StringInReverseOrder("oe93 kr"));
            //Console.WriteLine(Strings.NumberOfWords("This is sample sentence"));
            //Console.WriteLine(Strings.NumberOfWords("OK"));
            //Console.WriteLine(Strings.RevertWordsOrder("John Doe."));
            //Console.WriteLine(Strings.RevertWordsOrder("A, B. C"));
            //Console.WriteLine(Strings.HowManyOccurrences("do it now", "do"));
            //Console.WriteLine(Strings.HowManyOccurrences("empty", "d"));
            //Console.WriteLine(Strings.SortCharactersDescending("onomatopoeia"));
            //Console.WriteLine(Strings.SortCharactersDescending("fohjwf42os"));
            //Console.WriteLine(Strings.CompressString("kkkktttrrrrrrrrrr"));
            //Console.WriteLine(Strings.CompressString("p555ppp7www"));
            //Die die = new Die(3);
            //Console.WriteLine(die.RollAmount);
           Mozart.PlaySpecificFile();
        }




        static double AddAndMultiply(int first, int second, int third)
        {
            return (first + second) * third;
        }

        static string CtoF(double celsius)
        {
            double fah = (celsius * 9 / 5) + 32;

            if (celsius < -271.15)
            {
                return "Temperature below absolute zero!";
            }

            return $"T = {celsius}F";
        }

        static string ElementaryOperations(int first, int second)
        {
            string result = string.Empty;
            result += $"{first + second}, ";
            result += $"{first - second}, ";
            result += $"{first * second}, ";
            result += $"{(double)first / second}";

            return result;
        }

        static bool IsResultTheSame(int a, int b)
        {
            if (a == b)
            {
                return true;
            }

            return false;
        }

        static int ModuloOperations(int first, int second, int third)
        {
            return (first % second) % third;
        }

        static double CubeOf(double num)
        {
            return num * num * num;
        }

        static string SwapTwoNumbers(double first, double second)
        {
            double[] tempArr = { first, second };

            Array.Reverse(tempArr);

            return tempArr[0].ToString() + tempArr[1].ToString();
        }

        static int AbsoluteValue(int num)
        {
            return Math.Abs(num);
        }

        static int DivisibleBy2Or3(int first, int second)
        {
            if ((first / 3 == 0 || first / 2 == 0) && (second / 3 == 0 || second / 2 == 0))
            {
                return first * second;
            }

            return first + second;
        }

        static bool IfConsistsOfUppercaseLetters(string text)
        {
            return text.All(char.IsUpper);
        }

        static bool IfGreaterThanThirdOne(int[] arr)
        {
            if ((arr[0] * arr[1]) < arr[2])
            {
                return false;
            }

            return true;
        }

        static bool IfNumberIsEven(int num)
        {
            return int.IsEvenInteger(num);
        }

        static bool IfSortedAscending(int[] arr)
        {
            int[] tempArr = arr.OrderBy(n => n).ToArray();

            if (tempArr == arr)
            {
                return true;
            }

            return false;
        }

        static string PositiveNegativeOrZero(double num)
        {
            if (double.IsNegative(num))
            {
                return "negative";
            }
            else if (num == 0)
            {
                return "zero";
            }

            return "positive";
        }

        static bool IfYearIsLeap(int year)
        {
            if (year % 4 == 0)
            {
                return true;
            }

            return false;
        }

        static string NumberTable()
        {
            return "\r\n1\t2\t3\t4\t5\t6\t7\t8\t9\t10\r\n2\t4\t6\t8\t10\t12\t14\t16\t18\t20\r\n3\t6\t9\t12\t15\t18\t21\t24\t27\t30\r\n4\t8\t12\t16\t20\t24\t28\t32\t36\t40\r\n5\t10\t15\t20\t25\t30\t35\t40\t45\t50\r\n6\t12\t18\t24\t30\t36\t42\t48\t54\t60\r\n7\t14\t21\t28\t35\t42\t49\t56\t63\t70\r\n8\t16\t24\t32\t40\t48\t56\t64\t72\t80\r\n9\t18\t27\t36\t45\t54\t63\t72\t81\t90\r\n10\t20\t30\t40\t50\t60\t70\t80\t90\t100\r\n";
        }
       
    }
}