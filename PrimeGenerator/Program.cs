using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PrimeGenerator
{
    class Program
    {
        #region Main Loop
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Prime Generator!");
            Console.WriteLine("Please enter an integer greater than 1");
            Console.WriteLine("to see a list of all the prime numbers");
            Console.WriteLine("less than that input.");
            Console.WriteLine("");
            Console.WriteLine("Enter \"quit\" to exit.");

            string inputString = "";
            Generator primeGenerator = new Generator();

            do
            {
                inputString = Console.ReadLine();
                string output = "";

                if (IsNumeric(inputString))
                {
                    int input = int.Parse(inputString);
                    int[] primes = primeGenerator.GeneratePrimes(input);
                    output = StringifyPrimes(primes);
                }
                else
                {
                    // if NaN, ask for another integer
                    output = "Please enter an integer greater than 1.";
                }

                Console.WriteLine(output);
            } while (inputString != "quit");
        }
        #endregion


        #region Helper Methods
        /// <summary>
        /// Checks whether a string can be read as an integer.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        /// <summary>
        /// Takes an array of ints and returns a concatenated string
        /// of format "1, 2, 3, 4, 5". If no primes are found,
        /// returns a message to that effect.
        /// </summary>
        /// <param name="primesArray"></param>
        /// <returns></returns>
        private static string StringifyPrimes(int[] primes)
        {
            if (primes.Count() > 0)
            {
                string primesString = string.Join(", ", primes);
                return primesString;
            }

            return "No primes were found.";
        }

        #endregion
    }
}
