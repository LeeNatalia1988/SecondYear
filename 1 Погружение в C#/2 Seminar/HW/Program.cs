/*int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } }; Отсортировать по возрастанию.*/
namespace HW
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
            int[] newArray = new int[a.GetLength(0) * a.GetLength(1)];
            int count = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    newArray[count] = a[i, j];
                    count++;
                }
            }
            Array.Sort(newArray);
            count = 0;
            for (int i = 0;i < a.GetLength(0); i++)
            {
                for(int j = 0;j < a.GetLength(1); j++)
                {
                    a[i, j] = newArray[count];
                    Console.Write($"{a[i, j]}  ");
                    count++;
                }
                Console.WriteLine();
            }

        }
    }
}
