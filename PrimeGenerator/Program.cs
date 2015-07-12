using System;
using System.Collections.Generic;
using System.Globalization;
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

            string input = "";
            Generator primeGenerator = new Generator();

            do
            {
                input = Console.ReadLine();
                string output = primeGenerator.GeneratePrimes(input);
                Console.WriteLine(output);
            } while (input != "quit");
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
        #endregion
    }
}
