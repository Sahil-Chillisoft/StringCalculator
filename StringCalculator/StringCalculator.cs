using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        /*
         * Attempt No.5
         * Inclusion of testing cases of negative numbers.
         */

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.StartsWith("//"))
                return Convert.ToInt32(input[4].ToString()) + Convert.ToInt32(input[6].ToString());

            var delimiters = new List<char>{',', '\n'};
            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            if (numbers.Length > 0)
            {
                if (numbers.Any(num => Convert.ToInt32(num) < 0))
                    throw new Exception("Negative numbers are not allowed");
                return numbers.Sum(int.Parse);
            }

            return 0;
        }
    }
}

