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
        public void NaN()
        {
            string output = pg.GeneratePrimes("cow");
            Assert.AreEqual(output, "Please enter an integer.");
        }

        [TestMethod]
        public void GetPrimesNeg()
        {
            string output = pg.GeneratePrimes("-50");
            Assert.AreEqual("",output);
        }

        [TestMethod]
        public void GetPrimes0()
        {
            string output = pg.GeneratePrimes("0");
            Assert.AreEqual("", output);
        }

        [TestMethod]
        public void GetPrimes1()
        {
            string output = pg.GeneratePrimes("1");
            Assert.AreEqual("", output);
        }

        [TestMethod]
        public void GetPrimes100()
        {
            string output = pg.GeneratePrimes("100");

            int[] intArray = ConcatenatedStringToIntArray(output);

            Assert.AreEqual(25, intArray.Count());
            Assert.AreEqual(97, intArray[intArray.Count() - 1]);
        }

        [TestMethod]
        [TestCategory("Exhaustive")]
        public void ExhaustivePrimesTest()
        {
            for (int i = 2; i <= 500; i++)
                VerifyPrimeList(
                    ConcatenatedStringToIntArray(
                        pg.GeneratePrimes(i.ToString())
                    ));
        }

        #region Helper Methods
        private int[] ConcatenatedStringToIntArray(string output)
        {
            string[] stringArray = output.Split(',');
            int count = stringArray.Count();
            int[] intArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                intArray[i] = int.Parse(stringArray[i].Trim());
            }
            return intArray;
        }

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
