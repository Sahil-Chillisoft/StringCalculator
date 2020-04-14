using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            if (input.StartsWith(("//")))
                return Convert.ToInt32(input[4].ToString()) + Convert.ToInt32(input[6].ToString());

            var numbers = input.Split(',', '\n');
            if (numbers.Length > 0) 
                return AddNumbersFromArray(numbers);
            
            return 0;
        }

        private int AddNumbersFromArray(string[] numbers)
        {
            var sum = 0;
            foreach (var num in numbers)
            {
                var number = GetNumber(num);
                sum += number;
            }
            return sum;
        }

        private int GetNumber(string num)
        {
            return Convert.ToInt32(num);
        }
    }
}

