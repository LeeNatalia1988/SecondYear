using System.Collections;
using System.Linq;


namespace HW
{
    internal class Program
    {
        public static void Main(string[] args)
        {


            /*Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
            Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два
            числа равных по сумме первому.*/
            double[] array = new double[10] {1, 2, 3, 2, 5, 6, 7, 8, 10, 9};
            double number = 27;
            findNumbers1(array, number); // один вариант решения
            findNumbers2(array, number); // второй вариант
            findNumbers3(array, number); // третий вариант решения (намешала много чего, хотела попробовать)
        }
        public static void findNumbers1(double[] array, double number) {
            for (int i = 0; i < array.Length; i++)
            {
                double temp = number - array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    double temp1 = temp - array[j];
                    for (int k = j + 1; k < array.Length; k++)
                    {
                        if (array[k] == temp1)
                        {
                            Console.WriteLine($"Искомые числа и их индексы: {array[i]} [{i}], {array[j]} [{j}], {array[k]} [{k}].");
                        }
                    }
                }
            }
        }

        public static void findNumbers2(double[] array, double number)
        {
            var hs = new HashSet<double>();   
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                double temp = number - array[i] - array[i+1];
                if (hs.Contains(temp))
                {
                    Console.WriteLine($"Искомые числа: {array[i]}, {array[i+1]}, {temp}");
                }
                else
                {
                    hs.Add(array[i]);
                }
            }
        }

        public static void findNumbers3(double[] array, double number)
        {
            for (int i = 0; i < array.Length - 2; i++)
            {
                double temp = number - array[i] - array[i+1];
                for (int j = i + 2; j < array.Length; j++) 
                {
                    IEnumerable<double> numbers = array.Where(x => x == temp);
                    if (numbers.Count() > 0)
                    {
                        Console.Write($"Искомые числа и их индексы: {numbers.ElementAt(0)} [{j}], {array[i]} [{i}], {array[i+1]} [{i+1}].");
                        
                    }
                }
            }
            
        }
    }
}


