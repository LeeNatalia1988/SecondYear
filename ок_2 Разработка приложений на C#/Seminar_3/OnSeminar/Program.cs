using System.Collections;
using System.Diagnostics;
using System.Threading.Channels;

namespace OnSeminar
{
    internal class Program
    {
        static void Main()
        {

            /*
             * I
             * Используя стек инвертируйте порядок следования элементов в спиcке
            Пример списка
            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            Пример результата
            { 5,4,3,2,1}

            List<int> ints = new List<int> { 1, 2, 3, 4, 5 };
            Reverse(ints);
            foreach (int i in ints)
            {
                Console.Write($"{i} ");
            }
        }
        public static void Reverse(List<int> ints)
        {
            Stack<int> stack = new Stack<int>(ints.Capacity);
            foreach (int i in ints)
            {
                stack.Push(i);
            }
            ints.Clear();
            while (stack.Count != 0)
            {
                ints.Add(stack.Pop());
            }
            
        }*/
            /*II
             Реализуйте класс с поддержкой IEnumerable<int> - CustomEnumerale который в случае использования его в следующем коде
             foreach (var x in new CustomEmumerable())
             {
                Console.WriteLine(x);
             }
             Выведет на экран значения от 0 до 10.
             Подумайте, возможно вам придется реализовать не только IEnumerable но и IEnumerator

            foreach (var x in new CustomEmumerable())
            {
                Console.WriteLine(x);
            }*/
            /*III
             * Есть лабиринт описанный в виде двумерного массива где 1 это стены, 0 - проход, 2 - искомая цель.
            Пример лабиринта:
            1 1 1 1 1 1 1
            1 0 0 0 0 0 1
            1 0 1 1 1 0 1
            0 0 0 0 1 0 2
            1 1 0 0 1 1 1
            1 1 1 1 1 1 1
            1 1 1 1 1 1 1
            Напишите алгоритм определяющий наличие выхода из лабиринта и выводящий на экран координаты точки выхода если таковые имеются.

            Пример описания лабиринта.
            int[,] labirynth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 }
            };
            Пример заголовка функции которая должна определить наличие выхода из лабиринта:
            static bool HasExix(int startI, int startJ, int[,] l)
            startI,startJ это точка начала пути-откуда мы начинаем проходить лабиринт.
            l - массив описывающий лабиринт.*/

            int[,] labirynth1 = new int[,]
            {
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {0, 0, 0, 0, 1, 0, 2 },
            {1, 1, 0, 0, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1, 1, 1 }
            };

            int startI = FindStart(labirynth1)[0];
            int startJ = FindStart(labirynth1)[1];
            if (startI != 123456 && startJ != 123456) { Console.WriteLine($"Вход найден: [{startI}, {startJ}]."); }
            if (!HasExit(startI, startJ, labirynth1)) { Console.WriteLine("Выход не найден."); }
            
            
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

            static bool HasExit(int startI, int startJ, int[,] labirynth)
            {
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
                        return true;
                    }
                        
                    labirynth[i, j] = 1;
                    if(i - 1 >= 0 && labirynth[i - 1, j] != 1)
                        position.Enqueue((i - 1, j));
                    if (i + 1 < labirynth.GetLength(0) && labirynth[i + 1, j] != 1)
                        position.Enqueue((i + 1, j));
                    if (j - 1 >= 0 && labirynth[i, j - 1] != 1)
                        position.Enqueue((i, j - 1));
                    if (j + 1 < labirynth.GetLength(1) && labirynth[i, j + 1] != 1)
                        position.Enqueue((i, j + 1));
                }
                return false;
            }
        }
    }
}

