using System.ComponentModel.Design;

namespace Test
{
    internal class Program
    {
        /*модифицировать программу-калькулятор таким образом, чтобы она проверяла количество введенных аргументов и, 
            в случае если оно равно 2, выводила в консоль результат их сложения; если же количество аргументов отличается, 
            выводила инструкцию по использованию программы.
        */
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                if ((int.TryParse(args[0], out int num1)) && (int.TryParse(args[1], out int num2)))
                {
                    Console.WriteLine($"Сумма равна = {num1 + num2}");
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный формат данных.");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели больше или меньше двух чисел, перезапустите калькулятор.");
            }
        }
    }
}
