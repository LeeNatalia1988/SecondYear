using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    
    internal class CalculatorDivideByZeroException : Exception
    {
        public CalculatorDivideByZeroException(string message) : base(message)
        {

        }

    }
}
