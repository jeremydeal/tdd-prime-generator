using System;
using System.Linq;

namespace PrimeGenerator
{
    public class Generator
    {
        public string GeneratePrimes(string input)
        {
            if (IsNumeric(input))
            {
                int max = int.Parse(input);
                string output = "";

                // we only need to check for primes greater than 1
                if (max > 1)
                {
                    bool[] crossedOutNumbers = UncrossNumbersToCheck(max);
                    crossedOutNumbers = CrossOutNumbers(crossedOutNumbers);
                    int[] primes = PopulatePrimesArray(crossedOutNumbers);
                    output = StringifyPrimes(primes);
                }

                return output;
            }
            else
                return "Please enter an integer.";
        }

        private string StringifyPrimes(int[] primesArray)
        {
            string output = string.Join(", ", primesArray);
            return output;
        }

        private int[] PopulatePrimesArray(bool[] crossedOutNumbers)
        {
            int[] primes = new int[CountPrimes(crossedOutNumbers)];
            int index = 0;

            for (int i = 0; i < crossedOutNumbers.Count(); i++)
            {
                if (crossedOutNumbers[i] == false)
                {
                    primes[index++] = i;
                }
            }

            return primes;
        }

        /// <summary>
        /// Count the primes in order to set an array size.
        /// </summary>
        /// <returns></returns>
        private int CountPrimes(bool[] crossedOutNumbers)
        {
            int count = 0;

            foreach (bool num in crossedOutNumbers)
            {
                if (num == false)
                {
                    count++;
                }
            }

            return count;
        }

        private bool[] CrossOutNumbers(bool[] crossedOutNumbers)
        {
            bool[] output = crossedOutNumbers;
            int limit = GetMultiplesLimit(output.Count() - 1) + 1;

            for (int i = 2; i < limit; i++)
            {
                // we only need to cross out the multiples of primes...
                if (output[i] == false)
                {
                    // cross out all multiples of i
                    for (int j = i*2; j < output.Count(); j += i)
                    {
                        output[j] = true;
                    }
                }
            }

            return output;
        }

        /// <summary>
        /// Any non-prime below the given value must have a prime factor less
        /// than the square root of that value.
        /// </summary>
        /// <returns></returns>
        private int GetMultiplesLimit(int max)
        {
            return (int)Math.Sqrt(max);
        }

        private bool[] UncrossNumbersToCheck(int max)
        {
            bool[] output = new bool[max + 1];

            output[0] = output[1] = true;

            for (int i = 2; i < output.Count(); i++)
            {
                output[i] = false;
            }

            return output;
        }

        #region Helper Methods
        /// <summary>
        /// Checks whether a string can be read as an integer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
        #endregion
    }
}