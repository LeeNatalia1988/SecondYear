using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnSeminar
{
    internal interface ICalculator
    /*
     Модифицируйте код калькулятора следующим образом реализовав представленный ниже интерфейс:
    interface ICalc
    {
    event EventHandler<EventArgs> GotResult;
    void Add(int i);
    void Sub(int i);
    void Div(int i);
    void Mul(int i);
    void CancelLast();
    }

    Арифметические методы должны выполняться как обычно а метод CancelLast должен отменять последнее действие. 
    При этом метод может отменить последовательно все действия вплоть до самого последнего. 
    */
    {
        void Add(double number);
        void Sub(double number);
        void Mul(double number);
        void Div(double number);
        void CancelLast();

        event EventHandler<OperandChengedEventArgs> GotResult;
    }
}
