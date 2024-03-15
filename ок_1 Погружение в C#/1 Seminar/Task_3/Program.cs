using System.Diagnostics.CodeAnalysis;

namespace Task_3
{
    internal class Program
    {
        /*Написать программу, ищущую среднее арифметическое значение из введенных аргументов, 
         * передаваемых через параметры командной строки.
         */
        static void Main(string[] args)
        {
            if (args.Length != 0) {
                int count = 0;
                float sum = 0;
                foreach (string arg in args)
                {
                    if(int.TryParse(arg, out int num))
                    {
                        sum += num;
                        count++;
                    }
                }
                if (count != 0)
                {
                    Console.WriteLine($"Среднее арифметическое среди введенных чисел = {Math.Round((sum / count), 2)}");
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный формат данных, среди нет ни одного числа.");
                }
            }
            else
            {
                Console.WriteLine("Вы не ввели данные.");
            }
        }
    }
}
