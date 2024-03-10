using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal interface ICalculator
    
    {
        void Add(double number);
        void Sub(double number);
        void Mul(double number);
        void Div(double number);
        void CancelLast();

        event EventHandler<OperandChengedEventArgs> GotResult;
    }
}
