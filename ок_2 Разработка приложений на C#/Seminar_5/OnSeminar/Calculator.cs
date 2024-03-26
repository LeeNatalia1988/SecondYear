using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<OperandChengedEventArgs> GotResult;
        public Stack<double> result = new Stack<double>();
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
            if (number != 0)
            {
                Result /= number;
                result.Push(Result);
            }
            else
            {
                Console.WriteLine("Делить на 0 нельзя.");
            }
        }

        public void CancelLast()
        {
            if (result.Count != 0)
            {
                result.Pop();
                RaiseEvent();
            }
        }
    }
}
