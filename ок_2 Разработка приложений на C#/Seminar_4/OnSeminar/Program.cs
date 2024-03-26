using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OnSeminar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Дан список целых чисел(числа не последовательны), в котором некоторые числа повторяются.
            Выведите список чисел на экран, исключив из него повторы. C HashSet и без.
            List<int> ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };
            
            HashSet<int> set = new HashSet<int>(ints);
            List<int> list = new List<int>();
            Console.Write("{ ");
            foreach (int i in set)
            {                
                Console.Write($"{i}, ");
            }
            Console.Write(" }");
            Console.WriteLine();

            Console.Write("{ ");
            for (int i = 0; i < ints.Count; i++)
            {
                if (!list.Contains(ints[i]))
                {
                    list.Add(ints[i]);
                    Console.Write($"{ints[i]}, ");
                }
            }
            Console.Write(" }");
            Console.WriteLine();

            List<int> list1 = new List<int>();
            Console.Write("{ ");
            foreach (int i in ints)
            {
                if (!list1.Any(x => x == i || x == -i)) list1.Add(i); 
            }
            foreach (int i in list1)
            {
                Console.Write($"{i}, ");
            }
            Console.Write(" }");*/

            /*Дан список целых чисел(числа не последовательны), в котором некоторые числа повторяются.
             * Выведите список чисел на экран, расположив их в порядке возрастания частоты повторения
            List<int> ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };*/

            /*List<int> ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };
            sortDictionary(ints);
        }

        public static void sortDictionary(List<int> ints)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int i in ints)
            {
                if (dic.ContainsKey(i))
                {
                    dic[i]++;
                }
                else
                {
                    dic.Add(i, 1);
                }
            }
            /*Console.WriteLine("Цифра: Количество:");
            foreach (var d in dic.OrderBy(x => x.Value))
            {
                Console.WriteLine($"  {d.Key}    -    {d.Value}");
            }*/


            /*var priorityQueue = new PriorityQueue<int, int>();
            foreach(var d in dic)
            {
                priorityQueue.Enqueue(d.Key, d.Value);
            }
            while (priorityQueue.TryDequeue(out var number, out var count))
            {
                Console.WriteLine($"Цифра: {number}, Количество: {count}");
            }
            
            var priorityQueue = new PriorityQueue<int, int>();
            foreach (var d in dic)
            {
                priorityQueue.Enqueue(d.Key, -d.Value);
            }
            while (priorityQueue.TryDequeue(out var number, out var count))
            {
                Console.WriteLine($"Цифра: {number}, Количество: {Math.Abs(count)}");
            }*/




            /*У вас есть список студентов.Необходимо отфильтровать студентов старше 20 лет и отсортировать их по алфавиту.*/
            /*Задача: У вас есть список студентов. Необходимо вывести первые 5 студентов и пропустить первых 3 студентов.*/
            List<Student> students = new List<Student>();
            students.Add(new Student("Иванов Иван Иванович", 21));
            students.Add(new Student("Петров Петр Петрович", 20));
            students.Add(new Student("Сидоров Сидр Сидорович", 23));
            students.Add(new Student("Кандибобер Бургеркинг", 24));
            students.Add(new Student("Иванова Мария Андреевна", 18));
            students.Add(new Student("Иванова Клавдия Петровна", 22));
            students.Add(new Student("Иванова Клавдия Петровна", 22));
            students.Add(new Student("Иванова Клавдия Петровна", 22));
            students.Add(new Student("Иванова Клавдия Петровна", 22));
            students.Add(new Student("Иванова Клавдия Петровна", 22));
            /*foreach (Student student in students.OrderBy(x => x.FullName).Where(a => a.Age >= 20))
            {
                Console.WriteLine($"Полное имя студента: {student.FullName}, возраст: {student.Age}");
            }*/
            
            /*foreach (Student student in students.Skip(3).Take(5))
            {
                Console.WriteLine($"Полное имя студента: {student.FullName}, возраст: {student.Age}");
            }*/
        }
        /*public class Student
        {
            public string FullName { get; set; }
            public int Age { get; set; }

            public Student(string FullName, int Age)
            {
                this.FullName = FullName;
                this.Age = Age;
            }
        }*/
    }
}

