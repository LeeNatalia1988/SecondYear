using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<OperandChengedEventArgs> GotResult;
        public static Stack<double> result = new Stack<double>();
        private double Result 
        {
            get
            {
                return result.Count() == 0 ? 0 : result.Peek();
            } 
            set 
            { 
                result.Push(value);
                RaiseEvent(); 
            }
        }

        public void RaiseEvent()
        {
            GotResult?.Invoke(this, new OperandChengedEventArgs(Result));   
        }
        public void Add(double number)
        {
            Result += number;
        }

        public void Div(double number)
        {
            Result -= number;
        }

        public void Mul(double number)
        {
            Result *= number;
        }

        public void Sub(double number)
        {
            Result /= number;
        }

        public void CancelLast()
        {
            if (result.Count != 0)
            {
                result.Pop();
                Console.Write($"Результат: ");
                RaiseEvent();
            }
            else
            {
                Console.WriteLine("Отменять больше нечего.");
            }
        }
    }
}
