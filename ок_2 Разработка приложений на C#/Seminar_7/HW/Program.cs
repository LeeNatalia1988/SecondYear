using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HW
{
    internal class Program
    {
        static void Main()
        {
            //Task1();
            Task2();
        }
        /*Дан класс(ниже), создать методы создающий этот класс вызывая один из его 
             * конструкторов(по одному конструктору на метод).*/
        public static void Task1()
        {
            Type type = typeof(TestClass);
            var test1 = Activator.CreateInstance(type);
            var test2 = Activator.CreateInstance(type, 10);
            var test3 = Activator.CreateInstance(type, 10, new char[] { 'C', 'B' }, "S", 0.25m);
            Console.WriteLine(test1);
            Console.WriteLine(test2);
            Console.WriteLine(test3);
        }
        /*Напишите 2 метода использующие рефлексию
        1 - сохраняет информацию о классе в строку
        2- позволяет восстановить класс из строки с информацией о методе
        В качестве примере класса используйте класс TestClass.
        Шаблоны методов для реализации:
        static object StringToObject(string s) { }
        static string ObjectToString(object o) { }
        Строка должна содержать название класса, полей и значений
        Ограничьтесь диапазоном значений представленном в классе
        Если класс находится в тоже сборке (наш вариант) то можно не указывать имя сборки в паремтрах активатора.
        Activator.CreateInstance(null, “TestClass”) - сработает;
        Для простоты представьте что есть только свойства. Не анализируйте поля класса.
        Пример того как мог быть выглядеть сохраненный в строку объект: “TestClass, test2, Version=1.0.0.0, Culture=neutral, 
        PublicKeyToken=null:TestClass|I:1|S:STR|D:2.0|”
        Ключ-значения разделяются двоеточием а сами пары - вертикальной чертой.*/

        /*HW: Разработайте атрибут позволяющий методу ObjectToString сохранять поля классов с использованием произвольного имени.
        Метод StringToObject должен также уметь работать с этим атрибутом для записи значение в свойство по имени его атрибута.*/
        public static void Task2()
        {
            TestClass testClass = new TestClass(10, new char[] { 'A', 'B', 'C' }, "S", 0.25m);
            Console.WriteLine(ObjectToString(testClass));
            var result = StringToObject(ObjectToString(testClass));
        }

        static object StringToObject(string s)
        {
            
            String[] info = s.Split('\n', '|');
            foreach(String str2 in info)
            {
                Console.WriteLine(str2);
            }
            var fullName = info[0];
            var typeName = info[1];
            
            
            var o = Activator.CreateInstance(null, typeName).Unwrap();
            Type type = o.GetType();
            for (int i = 2; i < info.Length; i++)
            {
                string[] info2 = info[i].Split('=');
                var prop = type.GetProperty(info2[0]);
                if (prop == null) continue;
                else if (prop.PropertyType == typeof(int))
                {
                    prop.SetValue(o, int.Parse(info2[1]));
                }
                else if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(o, (string)info2[1]);
                }
                else if (prop.PropertyType == typeof(decimal))
                {
                    prop.SetValue(o, decimal.Parse(info2[1]));
                }
                else if (prop.PropertyType == typeof(char[]))
                {
                    prop.SetValue(o, info2[1].ToCharArray());
                }
            }
            return o;
        }

        static string ObjectToString(object o)
        {
            StringBuilder sb = new StringBuilder();
            Type type = o.GetType();
            sb.Append(type.Assembly + "\n");
            sb.Append(type.FullName + "\n");
            foreach (var pr in type.GetProperties())
            {
                //if (pr.GetCustomAttribute<DontSaveAttribute>() != null) continue;  
                var val = pr.GetValue(o, null);
                if (pr.PropertyType == typeof(char[]))
                {
                    sb.Append(pr.Name + "=" + new string(val as char[]) + "|");
                }
                else
                {
                    sb.Append(pr.Name + "=" + val + "|");
                }
            }
            var f = type.GetFields();
            foreach(var fi in f)
            {
                var attribute = fi.GetCustomAttribute<CustomName>();
                if(attribute != null)
                {
                    sb.Append(attribute.CN + "=");
                    var fiV = fi.GetValue(o);
                    sb.Append(fiV + "\n");
                }
            }
            return sb.ToString();
        }
    }
}
