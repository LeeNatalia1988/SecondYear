namespace HW
{
    internal class Program
    {
        /*Написать программу-калькулятор, вычисляющую выражения вида a + b, a - b, a / b, a * b, 
         * введенные из командной строки, и выводящую результат выполнения на экран.*/
        static void Main(string[] args)
        {
            
            if (args.Length == 3)
            {
                float result = 0;
                if (float.TryParse(args[0], out float num1) && float.TryParse(args[2], out float num2))
                {
                    /*Первый вариант - через elif
                     * if (args[1] == "+")
                    {
                        result = num1 + num2;
                    }
                    else if (args[1] == "-")
                    {
                        result = num1 - num2;
                    }
                    else if (args[1] == "/")
                    {
                     if (num2 != 0)
                            {
                                result = num1 / num2;
                                Console.WriteLine($"Результат: {result}");
                            }
                            else
                            {
                                Console.WriteLine("Деление на 0 невозможно");
                                Environment.Exit(0);
                            }
                    }
                    else if (args[1] == "*")
                    {
                        result = num1 * num2;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели неверный формат данных.");
                        Environment.Exit(0);
                    }
                    Console.WriteLine($"Результат: {result}");*/


                    /*Второй вариант - через case*/

                    switch (args[1])
                    {
                        
                        case "+":
                            result = num1 + num2;
                            Console.WriteLine($"Результат: {result}");
                            break;
                        case "-":
                            result = num1 - num2;
                            Console.WriteLine($"Результат: {result}");
                            break;
                        case "/":
                            if (num2 != 0)
                            {
                                result = num1 / num2;
                                Console.WriteLine($"Результат: {result}");
                            }
                            else
                            {
                                Console.WriteLine("Деление на 0 невозможно");
                                break;
                            }
                            break;
                        case "*":
                            result = num1 * num2;
                            Console.WriteLine($"Результат: {result}");
                            break;
                        default: 
                            Console.WriteLine("Вы ввели неверный формат данных.");
                            break;
                        
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Вы ввели неверный формат данных.");
            }
        }
    }
}

