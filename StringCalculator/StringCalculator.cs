using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class StringCalculator
    {
        /*
        * Attempt No.10.
        * Conversion of logic to use LINQ.
        * Custom delimiter algorithm.
        */

        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var delimiters = new List<string> { ",", "\n" };

            if (input.StartsWith("//"))
            {
                input = input.Remove(0, 2);
                var delimiterString = input.Split('\n');
                input = delimiterString[1];
                var customDelimiters = GetCustomDelimiters(delimiterString[0]);
                delimiters.AddRange(customDelimiters);
            }

            var numbers = input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var filteredNumbers = numbers.Select(int.Parse).Where(n => n <= 1000).ToList();
            var negativeNumbers = filteredNumbers.Where(n => n < 0).ToList();

            if (negativeNumbers.Any())
                throw new Exception($"Negative numbers are not allowed: {string.Join(", ", negativeNumbers)}");

            return filteredNumbers.Sum();
        }

        public List<string> GetCustomDelimiters(string delimiterString)
        {
            var newDelimiters = new List<string>();
            var delimiters = delimiterString;

            while (delimiters.Contains('[') && delimiters.Contains(']'))
            {
                var startIndex = delimiters.IndexOf('[');
                var endIndex = delimiters.IndexOf(']');
                var newDelimiter = delimiters.Substring(startIndex + 1, endIndex - 1);
                newDelimiters.Add(newDelimiter);
                delimiters = delimiters.Remove(startIndex, endIndex + 1);
            }

            return newDelimiters.ToList();
        }
    }
}

