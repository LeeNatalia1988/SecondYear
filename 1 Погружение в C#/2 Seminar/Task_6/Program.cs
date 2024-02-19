/*
 string s = "Эта ст1рока не долж2на содерж345ать цифры67";*/
using System.Collections.Specialized;
using System.Text;

namespace Task_6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string s = "Эта ст1рока не долж2на содерж345ать цифры67";
            StringBuilder sb = new StringBuilder();
            foreach (var item in s)
            {
                if(!char.IsDigit(item))
                {
                    sb.Append(item);
                }   
            } 
            Console.WriteLine(sb.ToString());    
        }
     }
 }

