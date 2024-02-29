namespace HW
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
             Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:

            int[,] labirynth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 0 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 }
            };

            Сигнатура метода:

            static int HasExit(int startI, int startJ, int[,] l)*/
            int[,] labirynth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
            };

            int startI = FindStart(labirynth1)[0];
            int startJ = FindStart(labirynth1)[1];
            if (startI != 123456 && startJ != 123456) { Console.WriteLine($"Вход найден: [{startI}, {startJ}]."); }
            int count = HasExit(startI, startJ, labirynth1);

            if (count == 0) { Console.WriteLine("Выход не найден."); }
            else { Console.WriteLine($"Количество выходов: {count}"); }


            static int[] FindStart(int[,] labirynth)
            {
                for (int j = 0; j < labirynth.GetLength(1); j++)
                {
                    if (labirynth[0, j] == 0)
                    {
                        return [0, j];
                    }
                }
                for (int j = 0; j < labirynth.GetLength(1); j++)
                {
                    if (labirynth[labirynth.GetLength(0) - 1, j] == 0)
                    {
                        return [labirynth.GetLength(0) - 1, j];
                    }
                }
                for (int i = 1; i < labirynth.GetLength(0) - 2; i++)
                {
                    if (labirynth[i, 0] == 0)
                    {
                        return [i, 0];
                    }
                }
                for (int i = 1; i < labirynth.GetLength(0) - 2; i++)
                {
                    if (labirynth[i, labirynth.GetLength(1) - 1] == 0)
                    {
                        return [i, labirynth.GetLength(1) - 1];
                    }
                }
                return [123456, 123456];
            }

            static int HasExit(int startI, int startJ, int[,] labirynth)
            {
                int count = 0;
                Queue<(int, int)> position = new();
                if (labirynth[startI, startJ] != 1)
                {
                    position.Enqueue((startI, startJ));
                }

                while (position.Count > 0)
                {
                    (int i, int j) = position.Dequeue();
                    if (labirynth[i, j] == 2)
                    {
                        Console.WriteLine($"Выход найден. Координаты выхода: [{i}, {j}]");
                        count++;
                    }

                    labirynth[i, j] = 1;
                    if (i - 1 >= 0 && labirynth[i - 1, j] != 1)
                        position.Enqueue((i - 1, j));
                    if (i + 1 < labirynth.GetLength(0) && labirynth[i + 1, j] != 1)
                        position.Enqueue((i + 1, j));
                    if (j - 1 >= 0 && labirynth[i, j - 1] != 1)
                        position.Enqueue((i, j - 1));
                    if (j + 1 < labirynth.GetLength(1) && labirynth[i, j + 1] != 1)
                        position.Enqueue((i, j + 1));
                }
                return count;
            }
        }
    }
}
