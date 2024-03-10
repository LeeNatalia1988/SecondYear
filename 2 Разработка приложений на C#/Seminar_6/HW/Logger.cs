using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class Logger
    {
        private Stack<(double, string, double)> log = new Stack<(double, string, double)>();

        public void AddLog(double number1, string operation, double number2)
        {
            log.Push(new(number1, operation, number2));
        }
        public string GetLog()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" StackTrace: ");
            foreach (var log in log)
            {
                sb.Append(log.ToString());
            }
            return sb.ToString();
        }
    }
}
