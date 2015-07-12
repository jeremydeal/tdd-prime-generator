using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeGenerator;

namespace UnitTestProject1
{
    [TestClass]
    public class PrimeGeneratorTest
    {
        public Generator pg = new Generator();

        [TestMethod]
        public void GetPrimesNeg()
        {
            int[] output = pg.GeneratePrimes(-50);
            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetPrimes0()
        {
            int[] output = pg.GeneratePrimes(0);
            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetPrimes1()
        {
            int[] output = pg.GeneratePrimes(1);
            Assert.AreEqual(0, output.Count());
        }

        [TestMethod]
        public void GetPrimes100()
        {
            int[] output = pg.GeneratePrimes(100);

            Assert.AreEqual(25, output.Count());
            Assert.AreEqual(97, output[output.Count() - 1]);
        }

        [TestMethod]
        [TestCategory("Exhaustive")]
        public void ExhaustivePrimesTest()
        {
            for (int i = 2; i <= 500; i++)
                VerifyPrimeList(pg.GeneratePrimes(i));
        }

        #region Helper Methods
        private void VerifyPrimeList(int[] primes)
        {
            for (int i = 0; i < primes.Count(); i++)
                VerifyPrime(primes[i]);
        }

        private void VerifyPrime(int prime)
        {
            for (int factor = 2; factor < prime; factor++)
                Assert.IsTrue(prime % factor != 0);
        }
        #endregion
    }
}
