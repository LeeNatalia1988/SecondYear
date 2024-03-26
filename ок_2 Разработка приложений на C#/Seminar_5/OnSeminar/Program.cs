namespace OnSeminar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*Спроектируем интерфейс калькулятора, поддерживающего простые арифметические действия, 
             * хранящего результат и также способного выводить информацию о результате при помощи события*/
            ICalculator calculator = new Calculator();
            calculator.GotResult += Calculator_GotResult;
            calculator.Add(10);
            calculator.Mul(5);
            calculator.CancelLast();
            calculator.CancelLast();
            calculator.Add(10);

        }

        private static void Calculator_GotResult(object? sender, OperandChengedEventArgs e)
        {
            Console.WriteLine(e.Operand);
        }
    }
}
