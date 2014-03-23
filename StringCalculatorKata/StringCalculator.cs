using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata
{
    class StringCalculator
    {
        internal int Add(string numbers)
        {
            int result;
            if (Int32.TryParse(numbers, out result))
            {
                return result;
            }
            else return 0;
        }
    }
}
