/*Написать программу, выводящую количество единиц в двоичном представлении числа.*/
using System.Text;

namespace Task_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            while (num != 0) 
            {
                if (num % 2 == 1) 
                {
                    count++;
                }
                num /= 2;
            }
            Console.WriteLine($"Количество единиц в в двоичном представлении данного числа: {count}");
        }
    }

       
}

