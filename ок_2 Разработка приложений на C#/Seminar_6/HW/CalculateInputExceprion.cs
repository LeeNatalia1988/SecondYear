using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class CalculateInputExceprion : Exception
    {
        public CalculateInputExceprion(string message) : base(message) { }  
    }
}
