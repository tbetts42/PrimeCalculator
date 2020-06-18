using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrimeCalculator.Tests
{
    [TestClass]
    public class PrimeTests
    {
        [TestMethod]
        public void FirstPrimeIsTwo()
        {
            var finder = PrimeFinder.Instance;
            /// 1 -> 2
            /// 2 -> 3
            /// 3 -> 5
            /// 4 -> 7
            /// 5 -> 11

            var expectedPrime = 2;
            var foundPrime = finder.FindPrime(1);
            Assert.AreEqual(expectedPrime, foundPrime);
        }

        [TestMethod]
        public void FifthPrimeIsEleven()
        {
            var finder = PrimeFinder.Instance;
            /// 1 -> 2
            /// 2 -> 3
            /// 3 -> 5
            /// 4 -> 7
            /// 5 -> 11

            var expectedPrime = 11;
            var foundPrime = finder.FindPrime(5);
            Assert.AreEqual(expectedPrime, foundPrime);
        }

    }
}
