using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class StringCalculator
    {
        /*
         * Attempt No.6
         * Inclusion of testing cases for multiple negative numbers.
         */

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.StartsWith("//"))
                return Convert.ToInt32(input[4].ToString()) + Convert.ToInt32(input[6].ToString());

            var delimiters = new List<char> { ',', '\n' };
            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            if (numbers.Length > 0)
            {
                var negativeValues = new StringBuilder("");
                foreach (var num in numbers)
                {
                    if (Convert.ToInt32(num) < 0)
                        negativeValues.Append("," + num);
                }
                if (negativeValues.ToString() == "")
                    return numbers.Sum(int.Parse);
                throw new Exception($"Negative numbers are not allowed: {negativeValues.Remove(0, 1)}");
            }
            return 0;
        }
    }
}

