using OnSeminar;

namespace OnSeminar
{
            internal class Program
        {
            static void Main(string[] args)
            {/*
            List<int> nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12, 13, 14};
        var result = nums.MyWhere(x=>x%2 ==0);
            foreach(var x in result) 
            {
                Console.WriteLine(x);
            }
            */


                /*
                 * Задача 2
                 * Спроектируем интерфейс калькулятора, поддерживающего простые арифметические действия, 
                 * хранящего результат и также способного выводить информацию о результате  при помощи события

                */
                ICalc calculator = new Calculator();
                Logger logger = new Logger();

                calculator.GetResult += Calculator_GetResult;
                do
                {
                    try
                    {

                        Console.Write("Введите число: ");
                        int number = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите операцию (для выхода из программы введите 'q'): ");
                        string operation = Console.ReadLine();
                        logger.AddLog(number, operation);
                        switch (operation)
                        {
                            case "+":
                                calculator.Sum(number);
                                break;
                            case "-":
                                calculator.Subtract(number);
                                break;
                            case "*":
                                calculator.Multiply(int.MaxValue);
                                break;
                            case "/":
                                calculator.Divide(number);
                                break;
                            case "q":
                                return;
                                break;
                            default:
                                Console.WriteLine("Неверная команда");
                                break;
                        }
                    }
                    catch (CalculateOperationCauseOverflowException ex)
                    {
                        Console.WriteLine(ex.Message + logger.GetLog());
                    }
                    catch (CalculatorDivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message + logger.GetLog());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + logger.GetLog());
                    }

                } while (true);

                /*
                calculator.Sum(5);
                calculator.Divide(5);
                calculator.Multiply(5);
                calculator.Subtract(5);
                calculator.CancelLast();
                calculator.CancelLast();
                calculator.CancelLast();
                */
            }
            private static void Calculator_GetResult(object? sender, OperandChangedEventArgs e)
            {
                Console.WriteLine(e.Operand);
            }
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
            При этом метод может отменить последовательно все действия вплоть до самого последнего.Спросите как студенты планируют 
            реализовать отмену действия и если будут трудности с ответами то подскажите им про стек
            */

        }
    }

