using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    /*
 * В прошлой лекции мы реализовали метод CancelLast позволяющий отменить любое сделанное действие. 
 * Реализуйте класс - список, описывающий последовательность действий приведших исключению. 
 * Очевидно что класс калькулятора должен быть доработан чтобы хранить не только информацию 
 * необходимую нам для отмены но и информацию о самом действии
 * */
    internal class Logger
    {
        private Stack<(int, string)> log = new Stack<(int, string)>();

        public void AddLog(int number, string operation)
        {
            log.Push(new(number, operation));
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
