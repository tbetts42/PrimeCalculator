using System;
using System.Linq;

namespace PrimeCalculator
{
    public static class IntegerExtensions
    {

        public static bool IsEven(this int number)
        {
            return number.IsDivisibleBy(2);
        }

        public static bool IsDivisibleBy(this int number, int divisor)
        {
            var remainder = number % divisor;
            return remainder == 0;
        }

        public static bool IsPrime(this int number)
        {
            return PrimeFinder.Instance.IsPrime(number);
        }
    }
}
