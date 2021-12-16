using System;
using System.Text.RegularExpressions;

namespace pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string numString = "1287543"; //"1287543.0" will return false for a long
            long number1 = 0;
            bool canConvert = long.TryParse(numString, out number1);
            if (canConvert == true)
                Console.WriteLine("number1 now = {0}", number1);
            else
                Console.WriteLine("numString is not a valid long");

            byte number2 = 0;
            numString = "255"; // A value of 256 will return false
            canConvert = byte.TryParse(numString, out number2);
            if (canConvert == true)
                Console.WriteLine("number2 now = {0}", number2);
            else
                Console.WriteLine("numString is not a valid byte");

            decimal number3 = 0;
            numString = "27.3"; //"27" is also a valid decimal
            canConvert = decimal.TryParse(numString, out number3);
            if (canConvert == true)
                Console.WriteLine("number3 now = {0}", number3);
            else
                Console.WriteLine("number3 is not a valid decimal");
            string cadena = "H5la";
            int num = 0;
            for (int i = 0; i < cadena.Length; i++)
            {
                if (int.TryParse(cadena.Substring(i, 1), out num))
                {
                    Console.WriteLine("{0}", cadena.Substring(i, 1));
                }
                else
                {
                    Console.WriteLine(Char.IsLetter(cadena, i));
                }
            }
            char ch = '8';
            Console.WriteLine("No numero");
            Console.WriteLine(Char.IsLetter(ch));*/
            string cadena = "7";
            Console.WriteLine(Regex.IsMatch(cadena, @"^[a-z]+$"));
            Console.WriteLine(Regex.IsMatch(cadena, @"^[A-Z]+$"));
            Console.WriteLine(Regex.IsMatch(cadena, @"^[0-9]+$"));
        }

    }
}
