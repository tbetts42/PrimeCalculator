using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeCalculator
{
    public class PrimeFinder
    {
        /// <summary>
        /// Gets the singleton PrimeFinder.
        /// </summary>
        public static PrimeFinder Instance { get; } = new PrimeFinder();

        /// <summary>
        /// Private constructor to force use of singleton <see cref="Instance"/>
        /// </summary>
        private PrimeFinder()
        {
        }


        private readonly List<int> _foundPrimes = new List<int>();

        /// <summary>
        /// Gets the largest Prime number we've found.
        /// Returns 0 if we have no prime numbers.
        /// </summary>
        private int HighestPrime
        {
            get
            {
                return _foundPrimes.LastOrDefault();
            }
        }

        // Don't let this run forever
        // 10 is too low, but start somewhere
        const int MAX_PRIME_INDEX = 500;

        /// <summary>
        /// Finds the nth prime number.
        /// 1 -> 2
        /// 2 -> 3
        /// 3 -> 5
        /// 4 -> 7
        /// 5 -> 11
        /// </summary>
        /// <param name="index">1-based</param>
        /// <returns></returns>
        public int FindPrime(int index)
        {
            if (index > MAX_PRIME_INDEX)
            {
                throw new Exception($"I'm not going to find {index} prime numbers. Max is {MAX_PRIME_INDEX}");
            }

            if (index <= _foundPrimes.Count())
            {
                // 0-based list, but index starts at 1
                return _foundPrimes[index - 1];
            }

            // keep finding primes until we reach the right number
            while (_foundPrimes.Count < index)
            {
                FindNextPrime();
            }

            // this isn't really recursive, but sort of
            return FindPrime(index);
        }

        /// <summary>
        /// Starts with the last prime we found and looks for the next one
        /// and adds it to the list.
        /// </summary>
        private void FindNextPrime()
        {
            var lastNumber = HighestPrime;
            var foundPrime = false;
            while (!foundPrime)
            {
                var nextNumber = lastNumber + 1;
                foundPrime = IsNumberPrime(nextNumber);
                if (foundPrime)
                {
                    _foundPrimes.Add(nextNumber);
                }
                else
                {
                    lastNumber = nextNumber;
                }
            }
        }

        /// <summary>
        /// Checks if <paramref name="number"/> is prime.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool IsNumberPrime(int number)
        {
            // 1 isn't prime, nor 0, nor anything negative
            if (number <=1)
            {
                return false;
            }

            // have we see this before?
            // Note, this shouldn't ever be true because of how we're calling it
            if (_foundPrimes.Contains(number))
            {
                return true;
            }

            foreach (var foundPrime in _foundPrimes)
            {
                if (number.IsDivisibleBy(foundPrime))
                {
                    return false;
                }
            }

            // if it wasn't divisible by ANY number so far, it must be prime!
            return true;
        }

        public bool IsPrime(int number)
        {
            // need to check if it's possibly within our list
            if (number > HighestPrime)
            {
                BuildPrimeListUpTo(number);
            }

            // if it's still too big...
            if (number > HighestPrime)
            {
                throw new Exception($"Can't tell if {number} is prime. I only know {MAX_PRIME_INDEX} prime numbers. Max is {HighestPrime}");
            }

            return IsNumberPrime(number);
        }

        private void BuildPrimeListUpTo(int number)
        {
            while (HighestPrime < number && _foundPrimes.Count < MAX_PRIME_INDEX)
            {
                FindNextPrime();
            }
        }
    }
}
