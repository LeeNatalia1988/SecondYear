/*Найти в строке с текстом подстроку с числами (такая подстрока всего одна).*/
using System.Text;

namespace Task_4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string s = "Эта строка содержит числа 12345 в своей середине";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    sb.Append(s[i]);
                }
                
            }
            if (sb.Length > 0)
            {
                Console.WriteLine($"Строка содержит подстроку с числами: {sb.ToString()}");
            }
            else
            {
                Console.WriteLine("Строка не содержит подстроку с числами.");
            }
        }
    }
}
