using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    /*
     * Доработайте реализацию калькулятора разработав собственные типы  ошибок.
    CalculatorDivideByZeroException
    CalculateOperationCauseOverflowException
    */
    internal class CalculatorDivideByZeroException : Exception
    {
        public CalculatorDivideByZeroException(string message) : base(message)
        {

        }

    }
}
