using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            var delimiters = new List<string> { ",", "\n" };
            var numberSection = input;
            if (HasCustomDelimiter(input))
            {
                string delimiterSection;
                (delimiterSection, numberSection) = ParseInput(input);
                var customDelimiters = GetCustomDelimiters(delimiterSection);
                delimiters.AddRange(customDelimiters);
            }

            var numbers = numberSection.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            
            var filteredNumbers = numbers.Select(int.Parse).Where(n => n <= 1000).ToList();
            var negativeNumbers = filteredNumbers.Where(n => n < 0).ToList();

            if (negativeNumbers.Any())
                throw new Exception($"Negative numbers are not allowed: {string.Join(", ", negativeNumbers)}");

            return filteredNumbers.Sum();
        }

        public bool HasCustomDelimiter(string input)
        {
            return input.StartsWith("//");
        }

        public (string, string) ParseInput(string input)
        {
            input = input.Remove(0, 2);
            var sections = input.Split('\n');
            return (sections.First(), sections.Last());
        }

        public List<string> GetCustomDelimiters(string delimiters)
        {
            var delimiterSection = delimiters.Remove(0, 1);
            delimiterSection = delimiterSection.Remove(delimiterSection.Length - 1,1);
            var newDelimiters = delimiterSection.Split("][");
            return newDelimiters.ToList();
        }
    }
}

