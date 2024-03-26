using FamilyTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree.View
{
    internal class SearchView
    {
        public static void SayHello()
        {
            Console.WriteLine("Привет, это мое генеалогическое древо с ближайшими родственниками.");
        }

        public static int SearchRelatives()
        {
            Console.WriteLine("Введите имя того, чьих близких родственников хотите увидеть (Наталья - 1, Феликс - 2):");
            string name = Console.ReadLine();
            int personForSearch = 0;
            if (name != null)
            {
                try
                {
                    personForSearch = int.Parse(name);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Вы что-то не то ввели, перезапустите.");
                    Environment.Exit(0);
                }
                return personForSearch;
            }
            else { return 0; }
        }
    }
}
