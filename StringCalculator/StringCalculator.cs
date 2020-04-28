using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class StringCalculator
    {
        /*
        * Attempt No.9
        * Use of ReSharper templates
        */

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.StartsWith("//"))
                input = input.Remove(0, 2);

            var delimiters = new List<string> { ",", "\n", ";", "[***]", "***", "[*]", "[%]", "*", "%" };

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            var negativeNumbers = new StringBuilder("");
            var sum = 0;
            
            foreach (var number in numbers)
            {
                if (int.Parse(number) < 0)
                    negativeNumbers.Append(number + ",");
                else if (int.Parse(number) > 1000)
                    sum += 0;
                else
                    sum += int.Parse(number);
            }
            if (negativeNumbers.ToString() != "")
                throw new Exception(
                    $"Negative numbers are not allowed: {negativeNumbers.Remove(negativeNumbers.Length - 1, 1)}");
            return sum;
        }
    }
}

