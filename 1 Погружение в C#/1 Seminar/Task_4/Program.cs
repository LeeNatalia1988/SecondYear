using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace Task_4
{
    internal class Program
    {
        /*Написать программу ищущую минимальное значение из введенных аргументов, передаваемых через параметры командной строки.*/
        static void Main(string[] args)
        {
            float min = float.MaxValue;
            if (args.Length != 0)
            {
                /*foreach (string arg in args)
                {
                    if (float.TryParse(arg, out float value))
                    {
                        min = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Среди введенных данных нет ни одного числа.");
                        Environment.Exit(0); 
                    }
                       
                }*/
                
                foreach (string arg in args)
                {
                    if (float.TryParse(arg, out float value))
                    {
                        if (value < min)
                        {
                            min = value;
                        }
                    }
                    
                }
                if (min != float.MaxValue)
                {
                    Console.WriteLine($"Минимальное число: {min}");
                }
                else Console.WriteLine("Среди введенных данных нет ни одного числа.");

            }
        }
    }
}
