using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class OperandChengedEventArgs(double operand) : EventArgs
    {
        public double Operand => operand;
    }
}
