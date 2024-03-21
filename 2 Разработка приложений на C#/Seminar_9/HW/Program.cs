using HW;
using System.Xml.Linq;

namespace HW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Для проверки две строки: с массивом и без
            string json1 = """{"name":"Иван","lastname":"Иванов","age":20}""";
            string json2 = """{"Current":{"Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},"History":[{"Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}]}""";
            MyConvert xDoc1 = new MyConvert(json1);
            MyConvert xDoc2 = new MyConvert(json2);

        }
    }
}
