using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace HW
{
    internal class MyConvert
    {
        public MyConvert(string json)
        {
            //Создаем новые необходимые документы
            var xmlDoc = new XmlDocument();
            var rootNode = xmlDoc.AppendChild(xmlDoc.CreateElement("Element"));
            if (rootNode != null)
            {
                JsonDocument jsonDoc = JsonDocument.Parse(json);
                ConvertJsonToXml(jsonDoc.RootElement, rootNode);
            }
            //Настройки для более читабельного вывода в консоль (отступы и перенос строки)
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            setting.IndentChars = "\t";
            setting.NewLineChars = "\n";
                      
            using XmlWriter writer = XmlWriter.Create(Console.Out, setting);
            xmlDoc.Save(writer);
        }


        //Конвертация данных, а объктов и массивов рекурсивно
        private void ConvertJsonToXml(JsonElement jEl, XmlNode xmlNode)
        {
            switch (jEl.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (var property in jEl.EnumerateObject())
                    {
                        var newEl = xmlNode.OwnerDocument?.CreateElement(property.Name);
                        if (newEl != null)
                        {
                            xmlNode.AppendChild(newEl);
                            ConvertJsonToXml(property.Value, newEl);
                        }
                    }
                    break;

                case JsonValueKind.Array:
                    foreach (var value in jEl.EnumerateArray())
                    {
                        ConvertJsonToXml(value, xmlNode);
                    }
                    break;

                default:
                    var textNode = xmlNode.OwnerDocument?.CreateTextNode(jEl.ToString());
                    if (textNode != null)
                        xmlNode.AppendChild(textNode);
                    break;
            }
        }
    }
}
