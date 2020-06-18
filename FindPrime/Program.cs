using PrimeCalculator;
using System;
using System.Runtime.ExceptionServices;

namespace FindPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = GetNumberFromArgs(args);
            if (number == 0)
            {
                Console.WriteLine("To find the nth prime number, enter:");
                var save = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("FindPrime n");
                Console.ForegroundColor = save;
                return;
            }

            var prime = PrimeFinder.Instance.FindPrime(number);
            Console.WriteLine($"The {number}th Prime is {prime}");
        }

        private static bool GoodArgs(string[] args)
        {
            if (args.Length != 1)
            {
                return false;
            }

            var stringVal = args[0];
            if (!int.TryParse(stringVal, out var value))
            {
                return false;
            }
            return true;
        }

        private static int GetNumberFromArgs(string[] args)
        {
            if (args.Length != 1)
            {
                return 0;
            }

            var stringVal = args[0];
            if (int.TryParse(stringVal, out var value))
            {
                return value;
            }
            return 0;
        }


    }
}
