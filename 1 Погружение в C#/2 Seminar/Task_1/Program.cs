/*Написать программу, подсчитывающую количество чисел от 0 до 1000, делящихся на 3 без остатка.*/
namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i = 0; i < 1000; i=i+3)
            {
                count++;
                
            }
            Console.WriteLine($"Количество чисел от 0 до 3, делящихся на 3 без остатка: {count}");
        }
    }
}
