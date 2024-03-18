using System.IO;

namespace HW
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MySearchAddressFilesWithWord(args[0], args[1], args[2]);
        }
        
        static List<string> listAddress = new List<string>();
        public static void MySearchAddressFilesWithWord(string path, string extension, string word)
        {
            /*Объедините две предыдущих работы(практические работы 2 и 3): поиск файла и поиск текста в файле написав 
             * утилиту которая ищет файлы определенного расширения с указанным текстом.Рекурсивно.
             * Пример вызова утилиты: utility.exe txt текст.*/
            //PS: Все параметры, передаваемые в args нужно брать в "", если есть пробелы (в особенности в адресе)

            listAddress.AddRange(Directory.GetFiles(path, "*." + extension, SearchOption.AllDirectories));
            foreach (string file in listAddress)
            {
                using (var sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        var temp = sr.ReadLine();
                        if (temp.Contains(word))
                        {
                            Console.WriteLine(file);
                        }
                    }
                }
            }
        }
    }
}
