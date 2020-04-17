using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        /*
         * Attempt No.4
         * Code refactoring and optimizations using ReSharper.
         */

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.StartsWith(("//")))
                return Convert.ToInt32(input[4].ToString()) + Convert.ToInt32(input[6].ToString());

            var delimiters = new List<char>{',', '\n'};
            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length > 0) 
                return numbers.Sum(int.Parse);
            
            return 0;
        }
    }
}

