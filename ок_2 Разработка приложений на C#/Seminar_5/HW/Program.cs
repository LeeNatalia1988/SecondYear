using HW;
using System.ComponentModel.Design;

namespace HW
{
    internal class Program : Calculator
    {
        public static void Main(string[] args)
        {
            /*Доработайте программу калькулятор реализовав выбор действий и вывод результатов на экран в цикле так чтобы 
             * калькулятор мог работать до тех пор пока пользователь не нажмет отмена или введёт пустую строку.*/
            ICalculator calculator = new Calculator();
            calculator.GotResult += Calculator_GotResult;
            Console.WriteLine("Введите первое число, операцию и второе число через пробел или пустую строку для завершения программы: ");
            try
            {
                String[] startString = Console.ReadLine().Split(' ');
                if (startString.Length == 0)
                {
                    Console.WriteLine("Калькулятор закрыт.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                
                if (startString.Length != 0 && startString.Length > 2)
                {
                    StartMenu(startString);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Вы ввели неверный формат данных. {ex}");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            
            Console.WriteLine("Далее водите операцию и число через пробел, С для отмены предыдущего действия или Enter для завершения программы: ");
            bool contin = true;
            
            try
            {
                while (contin)
                {
                    String[] menu = Console.ReadLine().Split(' ');
                    if (menu.Length == 0)
                    {
                        Console.WriteLine("Калькулятор закрыт.");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        contin = false;
                    }
                    if (menu[0].ToUpper() == "C" || menu[0].ToUpper() == "С")
                    {
                        calculator.CancelLast();
                    }
                    if (menu.Length == 2)
                    {
                        Menu(menu);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Вы ввели неверный формат данных. {ex}");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        private static void Calculator_GotResult(object? sender, OperandChengedEventArgs e)
        {
            Console.WriteLine(e.Operand);
        }

        public static void StartMenu(String[] startString)
        {
            if (double.TryParse(startString[0], out double num1) && double.TryParse(startString[2], out double num2))
            {
                result.Push(num1);
                
                switch (startString[1])
                {
                    case "+":
                        result.Push(num1 + num2);
                        break;
                    case "-":
                        result.Push(num1 - num2);
                        break;
                    case "*":
                        result.Push(num1 * num2);
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            result.Push(num1 / num2);
                        }
                        else
                        {
                            Console.WriteLine("На ноль делить нельзя. Калькулятор закрыт.");
                            Thread.Sleep(2000);
                            Environment.Exit(0);
                        }
                        break;
                    default:
                        Console.WriteLine("Вы ввели неправильную операцию, попробуйте еще раз. Калькулятор закрыт.");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine($"Результат: {result.Peek()}");
            }
        }
        public static void Menu(String[] menu)
        {
            ICalculator calculator = new Calculator();
            if (double.TryParse(menu[1], out double number))
            {
                switch (menu[0])
                {
                    case "+":
                        calculator.Add(number);
                        break;
                    case "-":
                        calculator.Div(number);
                        break;
                    case "*":
                        calculator.Mul(number);
                        break;
                    case "/":
                        if (number != 0)
                        {
                            calculator.Sub(number);
                        }
                        else 
                        { 
                             Console.WriteLine("На ноль делить нельзя. Калькулятор закрыт.");
                             Thread.Sleep(2000);
                             Environment.Exit(0);
                        }
                        break;
                    default:
                        Console.WriteLine("Вы ввели неправильную операцию, попробуйте еще раз. Калькулятор закрыт.");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine($"Результат: {result.Peek()}");
            }
        }
    }
}


