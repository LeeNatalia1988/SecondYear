using HW;
using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HW
{
    internal class Program : Calculator
    {
        public static void Main(string[] args)
        {
            /*Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами. 
             * (возможно стоит задействовать перегрузку операций).*/
            ICalculator calculator = new Calculator();
            calculator.GotResult += Calculator_GotResult;
            Logger logger = new Logger();
            Console.WriteLine("Введите первое число, операцию и второе число через пробел или пустую строку для завершения программы: ");
            try
            {
                System.String[] startString = Console.ReadLine().Split(' ');
                if (startString.Length == 0)
                {
                    Console.WriteLine("Калькулятор закрыт.");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }

                if (startString.Length != 0 && startString.Length > 2 && (startString[1] == "+" || startString[1] == "-" || startString[1] == "*" || startString[1] == "/"))
                {
                    StartMenu(startString, logger);
                }
                else
                {
                    throw new CalculateInputExceprion("Вы ввели неверный формат данных. Калькулятор закрыт.");
                }
            }
            catch (CalculateInputExceprion ex)
            {
                Console.WriteLine(ex.Message);
                Thread.Sleep(2000);
                Environment.Exit(0);
            }

            Console.WriteLine("Далее водите операцию и число через пробел, С для отмены предыдущего действия или Enter для завершения программы: ");
            bool contin = true;

            try
            {
                while (contin)
                {
                    System.String[] menu = Console.ReadLine().Split(' ');
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
                        continue;
                    }
                    if (menu.Length == 2 && (menu[0] == "+" || menu[0] == "-" || menu[0] == "*" || menu[0] == "/"))
                    {
                        Menu(menu, logger);
                    }
                    else
                    {
                        throw new CalculateInputExceprion("Вы ввели неверный формат данных. Калькулятор закрыт.");
                        contin = false;
                    }
                }
            }
            catch (CalculateOperationCauseOverflowException ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            catch (CalculateInputExceprion ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        private static void Calculator_GotResult(object? sender, OperandChengedEventArgs e)
        {
            Console.WriteLine(e.Operand);
        }

        public static void StartMenu(System.String[] startString, Logger logger)
        {
            try
            {
                if (double.TryParse(startString[0], out double num1) && double.TryParse(startString[2], out double num2))
                {
                    result.Push(num1);
                    logger.AddLog(num1, startString[1], num2);
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
                                throw new CalculatorDivideByZeroException("На ноль делить нельзя. Калькулятор закрыт.");
                            }
                            break;
                        default:
                            {
                                throw new CalculateInputExceprion("Вы ввели неверный формат данных. Калькулятор закрыт.");
                                break;
                            }
                    }
                    Console.WriteLine($"Результат: {result.Peek()}");
                }
            }
            catch (CalculateInputExceprion ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
        public static void Menu(System.String[] menu, Logger logger)
        {
            ICalculator calculator = new Calculator();
            try
            {

                if (double.TryParse(menu[1], out double number))
                {
                    logger.AddLog(result.Peek(), menu[0], number);
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
                                throw new CalculatorDivideByZeroException("На ноль делить нельзя. Калькулятор закрыт.");
                                Thread.Sleep(2000);
                                Environment.Exit(0);
                            }
                            break;
                        default:
                            throw new CalculateInputExceprion("Вы ввели неправильную операцию. Калькулятор закрыт.");
                            break;
                    }
                    Console.WriteLine($"Результат: {result.Peek()}");
                }
            }
            catch (CalculateInputExceprion ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex.Message + logger.GetLog());
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
    }
}


