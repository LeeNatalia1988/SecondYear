using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnSeminar
{
    public class Program
    {
        public static void Main()
        {
            /*Task1
             * var dr = new Task1
            {
                Names = new List<string> { "Name1", "Name2", "Name3" },
                Entries = new List<DataEntry> 
                {
                new DataEntry{ LinkedEntry = "Name1", DataName = "Name2"},
                new DataExtendedEntry { LinkedEntry = "Name2", DataName = "Name1", ExtendedEntry = "NameOne"}
}
            };
            var serializer = new XmlSerializer(typeof(Task1));
            serializer.Serialize(Console.Out, dr);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
            using (StringReader sr = new StringReader(s))
            {
                Task1? obj1 = serializer.Deserialize(sr) as Task1;
                serializer.Serialize(Console.Out, obj1);
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            var obj = (Task1?)serializer.Deserialize(new StringReader(s));
            serializer.Serialize(Console.Out, obj);*/

            var res = (new JsonParser()).ParseJson(json, "Temperature");
            foreach (var line in res)
            {
                Console.WriteLine(line);
            }
        }

        public static string s = "<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
                    "<Data.Root xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"> " +
                    "<Data.Root.Names> " +
                    "<Name>Name1</Name> " +
                    " <Name>Name2</Name> " +
                    "<Name>Name3</Name> " +
                    "</Data.Root.Names> " +
                    "<Data.Entry LinkedEntry=\"Name1\"> " +
                    "<Data.Name>Name2</Data.Name> " +
                    " </Data.Entry> " +
                    "<Data_x0023_ExtendedEntry LinkedEntry=\"Name2\"> " +
                    " <Data.Name>Name1</Data.Name> " +
                    " <Data_x0023_Extended>NameOne</Data_x0023_Extended> " +
                    "</Data_x0023_ExtendedEntry> </Data.Root>";
        static string json = """{"Current":{"Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},"History":[{"Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},{"Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}]}""";


        [XmlRoot("Data.Root")]
        public class Task1
        {
            /*Создать класс, кот десериализует данный код:
             * 
             * "<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
                    "<Data.Root xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"> " +
                    "<Data.Root.Names> " +
                    "<Name>Name1</Name> " +
                    " <Name>Name2</Name> " +
                    "<Name>Name3</Name> " +
                    "</Data.Root.Names> " +
                    "<Data.Entry LinkedEntry=\"Name1\"> " +
                    "<Data.Name>Name2</Data.Name> " +
                    " </Data.Entry> " +
                    "<Data_x0023_ExtendedEntry LinkedEntry=\"Name2\"> " +
                    " <Data.Name>Name1</Data.Name> " +
                    " <Data_x0023_Extended>NameOne</Data_x0023_Extended> " +
                    "</Data_x0023_ExtendedEntry> </Data.Root>";*/
            public Task1() { }

            [XmlArray("Data.Root.Names")]
            [XmlArrayItem("Name")]
            public List<string> Names = new List<string>();

            [XmlElement(typeof(DataEntry))]
            [XmlElement(typeof(DataExtendedEntry))]
            [XmlElement("Data#ExtendedEntry")]
            public List<DataEntry> Entries = new List<DataEntry>();

        }

        [XmlRoot("Data.Entry")]
        public class DataEntry
        {
            public DataEntry() { }
            [XmlAttribute]
            public string LinkedEntry;
            [XmlElement("Data.Name")]
            public string DataName;
        }

        [XmlRoot("Data#ExtendedEntry")]
        public class DataExtendedEntry : DataEntry
        {
            public DataExtendedEntry() { }
            [XmlElement("Data#Extended")]
            public string ExtendedEntry;
        }
    }


    public class Task2
    {
        /*С сайта о погоде была получена информация о текущей и прошлой(за три дня) погоде в виде JSON.
         * Напишите класс способный хранить представленную информацию.
         * { 
         * "Current":{ "Time":"2023-06-18T20:35:06.722127+04:00","Temperature":29,"Weathercode":1,"Windspeed":2.1,"Winddirection":1},
         * "History":
         * [
         * { "Time":"2023-06-17T20:35:06.77707+04:00","Temperature":29,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
         * { "Time":"2023-06-16T20:35:06.777081+04:00","Temperature":22,"Weathercode":2,"Windspeed":2.4,"Winddirection":1},
         * { "Time":"2023-06-15T20:35:06.777082+04:00","Temperature":21,"Weathercode":4,"Windspeed":2.2,"Winddirection":1}
         * ]
         * }*/
        //[JsonPropertyName("Current")]
        public WeatherData Current { get; set; }
        //[JsonPropertyName("History")]
        public List<WeatherData> History { get; set; }
    }

    public class WeatherData
    {
        public WeatherData() { }
        //[JsonPropertyName("Time")]
        public DateTime Time { get; set; }
        //[JsonPropertyName("Temperature")]
        public double Temperature { get; set; }
        //[JsonPropertyName("Weathercode")]
        public int Weathercode { get; set; }
        //[JsonPropertyName("Windspeed")]
        public int Windspeed { get; set; }
        //[JsonPropertyName("Winddirection")]
        public int Winddirection { get; set; }
    }

    /*Напишите метод для поиска значений в JSON.В качестве JSON можно использовать JSON из предыдущего примера.
     * Метод должен принимать строку-название ключа и возвращать список найденных значений.Используйте например JsonDocument.Parse*/


    public class JsonParser
    {
        private string? _value;

        private List<string> _results = new List<string>();

        public List<string> ParseJson(string json, string value)
        {
            _value = value;
            var jsonDocument = JsonDocument.Parse(json);
            var root = jsonDocument.RootElement;
            parseElement(root);
            return _results;
        }

        private void parseElement(JsonElement element, bool save = false)
        {

            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    parseObject(element);
                    break;
                case JsonValueKind.Array:
                    parseArray(element);
                    break;
                case JsonValueKind.String:
                    parseString(element, save);
                    break;
                case JsonValueKind.Number:
                    parseNumber(element, save);
                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    ParseBoolean(element);
                    break;
                case JsonValueKind.Null:
                    ParseNull();
                    break;
                default:
                    throw new NotSupportedException("Unsupported JSON value kind: " + element.ValueKind);
            }
        }

        private void parseObject(JsonElement element)
        {
            foreach (var el in element.EnumerateObject())
            {
                Console.WriteLine($"Property = {el.Name}");
                bool save = el.Name == _value;
                parseElement(el.Value, save);
            }
        }

        private void parseArray(JsonElement element)
        {
            foreach (var el in element.EnumerateArray())
            {
                parseElement(el);
            }
        }

        private void parseString(JsonElement element, bool save = false)
        {
            if (save)
            {
                _results.Add(element.GetString());
            }
            Console.WriteLine($"String = {element.GetString()}");
        }

        private void parseNumber(JsonElement element, bool save = false)
        {
            if (save)
            {
                _results.Add(element.GetRawText());
            }
            Console.WriteLine($"Number = {element.GetRawText()}");
        }

        private void ParseBoolean(JsonElement element)
        {
            Console.WriteLine("Boolean value: " + element.GetBoolean());
        }

        private void ParseNull()
        {
            Console.WriteLine("Null value");
        }
    }
}
