using System.Text;
/*Дан двумерный массив.
123
456
789
Выведите его на печать перевернутым на 90 градусов
741
852
963*/
namespace Task_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] a = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int j = 0; j < a.GetLength(1); j++)
            {
                for (int i = a.GetLength(0) - 1; i >= 0; i--)
                {
                    Console.Write($"{a[i, j]}, ");
                }
                Console.WriteLine();
            }
            
        }
    }
}
