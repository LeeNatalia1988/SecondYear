
using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace OnSeminar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //MyUtility(args);
            /*MySearchAddress(args[0], args[1]); 
            foreach (string ls in listAddress) {
                Console.WriteLine(ls);
            }*/
            MySearchStringWithWord(args[0], args[1]);

        }
        public static void MySearchStringWithWord(string fileName, string word)
        {
            /*Напишите утилиту читающую тестовый файл и выводящую на экран строки содержащие искомое слово.*/
            using (var sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    var temp = sr.ReadLine();
                    if (temp.Contains(word))
                    {
                        Console.WriteLine(temp);
                    }
                }
            }
        }

        public static void MyUtility(string[] args)
        {
            /* Напишите консольную утилиту для копирования файлов
            Пример запуска: utility.exe file1.txt file2.txt*/
            if (args.Length != 2)
            {
                Console.WriteLine("Вы ввели неверные данные.");
            }
            else
            {
                if (!File.Exists(args[0]))
                {
                    using (var sw = new StreamWriter(args[0]))
                    {
                        sw.WriteLine("Что-нибудь.");
                        Console.WriteLine("Файл создан.");
                    }
                }

                using (var sr = new StreamReader(args[0]))
                {
                    using (var sw = new StreamWriter(args[1]))
                    {
                        sw.WriteLine(sr.ReadToEnd());
                    }
                }
                Console.WriteLine("Файл скопирован.");
            }
        }

        static List<string> listAddress = new List<string>();
        public static void MySearchAddress(string path, string name)
        {
            /*Напишите утилиту рекурсивного поиска файлов в заданном каталоге и подкаталогах
            Габиль Асланов Пример запуска: utility.exe c:\t file1.txt*/

            listAddress.AddRange(Directory.GetFiles(path, name, SearchOption.AllDirectories));
            /*var allFiles = Directory.GetFiles(path);
            
            foreach(var file in allFiles)
            {
                if(Path.GetFileName(file) == name)
                {
                    listAddress.Add(file);
                }
            }
            foreach(var dir in Directory.GetDirectories(path))
            {
                MySearch(dir, name);
            }*/

        }




    }
}







