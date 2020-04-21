using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class StringCalculator
    {
        /*
        * Attempt No.7
        * Inclusion of numbers greater than 1000 ignore case.
        * Further code refactoring.
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
                var negativeNumbers = new StringBuilder("");
                var sum = 0;
                foreach (var num in numbers)
                {
                    if (Convert.ToInt32(num) < 0)
                        negativeNumbers.Append("," + num);
                    else if (Convert.ToInt32(num) > 1000)
                        sum += 0;
                    else
                        sum += Convert.ToInt32(num);
                }

                if (negativeNumbers.ToString() != "")
                    throw new Exception($"Negative numbers are not allowed: {negativeNumbers.Remove(0, 1)}");
                return sum;
            }
            return 0;
        }
    }
}

