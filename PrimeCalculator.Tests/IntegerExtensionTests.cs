using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PrimeCalculator.Tests
{
    [TestClass]
    public class IntegerExtensionTests
    {
        [TestMethod]
        public void TwoIsEven()
        {
            var two = 2;
            var isTwoEven = two.IsEven();
            Assert.IsTrue(isTwoEven);
        }

        [TestMethod]
        public void ThreeIsNotEven()
        {
            var three = 3;
            var isThreeEven = three.IsEven();
            Assert.IsFalse(isThreeEven);
        }

        [TestMethod]
        public void SixIsDivisibleByTwo()
        {
            var six = 6;
            var isDivisible = six.IsDivisibleBy(2);
            Assert.IsTrue(isDivisible);
        }

        [TestMethod]
        public void SixIsDivisibleByThree()
        {
            var six = 6;
            var isDivisible = six.IsDivisibleBy(3);
            Assert.IsTrue(isDivisible);
        }

        [TestMethod]
        public void SixIsNotDivisibleByFive()
        {
            var six = 6;
            var isDivisible = six.IsDivisibleBy(5);
            Assert.IsFalse(isDivisible);
        }
        
        [TestMethod]
        public void SixIsNotPrime()
        {
            var six = 6;
            var isPrime = six.IsPrime();
            Assert.IsFalse(isPrime);
        }
        
        [TestMethod]
        public void FiveIsPrime()
        {
            var five = 5;
            var isPrime = five.IsPrime();
            Assert.IsTrue(isPrime);
        }


        [TestMethod]
        public void TooBigForIsPrimeThrowsException()
        {
            var bigNumber = 500000;
            try
            {
                var isPrime = bigNumber.IsPrime();
                Assert.Fail("Should've thrown an exception");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
        }

    }
}
