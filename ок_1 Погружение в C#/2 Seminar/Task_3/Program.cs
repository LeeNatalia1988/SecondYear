/*Даны массивы a и b, заполненные случайными числами. Необходимо создать массив c длиной, 
 * равной сумме длин массивов a и b, заполнить его элементами массивов a и b, отсортированными по возрастанию.*/

Console.WriteLine("Введите размеры массивов: ");
int[] arr1 = new int[Convert.ToInt32(Console.ReadLine())];
int[] arr2 = new int[Convert.ToInt32(Console.ReadLine())];
int[] result = new int[arr1.Length + arr2.Length];
Random rand = new Random();
for (int i = 0; i < arr1.Length; i++)
{
    arr1[i] = rand.Next(0, 100);
}
for (int i = 0; i < arr2.Length; i++)
{
    arr2[i] = rand.Next(0, 100);
}
Array.Copy(arr1, 0, result, 0, arr1.Length);
Array.Copy(arr2, 0, result, arr1.Length, arr2.Length);
Array.Sort(result);
Console.WriteLine(string.Join(", ", result));

        }
    }
}