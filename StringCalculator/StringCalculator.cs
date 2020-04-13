using System;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            string[] input = numbers.Split(new char[]{ ',', '\n'});
            int totalNumbers = input.Length;
            
            if (totalNumbers == 1)
                return Convert.ToInt32(input[0]);

            if (totalNumbers == 2)
                return Convert.ToInt32(input[0]) + Convert.ToInt32(input[1]);

            if (totalNumbers > 2)
            {
                int sum = 0;
                foreach (var num in input)
                {
                    sum += Convert.ToInt32(num);
                }
                return sum;
            }
            
            return 0;
        }
    }
}
