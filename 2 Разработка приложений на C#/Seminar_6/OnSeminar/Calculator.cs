using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    internal class Calculator : ICalc
    {


        public event EventHandler<OperandChangedEventArgs> GetResult;
        private Stack<int> stack = new Stack<int>();
        private int Result
        {
            get
            {
                return stack.Count() == 0 ? 0 : stack.Peek();

            }
            set
            {
                stack.Push(value);
                RaiseEvent();
            }
        }


        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
                RaiseEvent();
            }

        }
        public void RaiseEvent()
        {
            GetResult.Invoke(this, new OperandChangedEventArgs(Result));
        }


        public void Divide(int number)

        {
            try
            {

                if (number == 0)
                    throw new CalculatorDivideByZeroException("Деление на ноль недопустимо");
                Result /= number;


            }

            catch (OverflowException)
            {
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число");
            }
        }



        public void Multiply(int number)

        {
            try
            {
                checked
                {
                    Result *= number;
                }
            }
            catch
            {
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число");
            }

        }

        public void Subtract(int number)
        {
            try
            {

                Result -= number;

            }
            catch
            {
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число");
            }
        }

        public void Sum(int number)
        {
            try
            {

                Result += number;

            }
            catch
            {
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число");
            }
        }
    }
}
