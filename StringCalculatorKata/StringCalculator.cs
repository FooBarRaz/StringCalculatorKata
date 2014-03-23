using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata
{
    class StringCalculator
    {
        private ILogger Console; 

        public StringCalculator(ILogger console)
        {
            Console = console;
        }


        internal int Add(string numbers)
        {
            var result = 0;
            var numberList = SplitNumbers(numbers);
            foreach (var number in numberList)
            {
                int numberAsInt;
                if (Int32.TryParse(number, out numberAsInt))
                {
                    result += numberAsInt;
                }
            }
            Console.Write(result.ToString());
            return result;
        }


        private IEnumerable<string> SplitNumbers(string numbers)
        {
            numbers = numbers.Replace('\n', ',');
            return numbers.Split(',');
        }
    }
}
