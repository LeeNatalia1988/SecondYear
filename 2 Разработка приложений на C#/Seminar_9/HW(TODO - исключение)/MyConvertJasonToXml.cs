using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace HW
{
    internal class MyConvertJasonToXml
    {
        string json = """{"name":"Иван","age":25}""";
        public MyConvertJasonToXml(string json)
        {
            using (JsonDocument jDoc = JsonDocument.Parse(json))
            {
                /*TODO1-й способ, выдает исключение и я не знаю что с ним делать
                XDocument xDoc1 = new XDocument();
                ConvertJsonToXml(jDoc.RootElement, xDoc1.Root);
                xDoc1.Save("MyConvert.xml");*/
            }
            using (JsonDocument document = JsonDocument.Parse(json))
            {
                XmlElement rootElement = ConvertJsonToXml2(document.RootElement);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.AppendChild(xmlDocument.ImportNode(rootElement, true));
                //xmlDocument.Save("MyConvert.xml");
                XmlWriterSettings settings = new()
                {
                    Indent = true,
                    IndentChars = "\t"
                };
                using XmlWriter writer = XmlWriter.Create(Console.Out, settings);
                xmlDocument.Save(writer);
            }
        }

        public static void ConvertJsonToXml1(JsonElement jE, XElement xEl)
        {
            foreach (JsonProperty jP in jE.EnumerateObject())
            {
                if (jP.Value.ValueKind == JsonValueKind.Object)
                {
                    var childXmlEl = new XElement(jP.Name);
                    if (childXmlEl != null)
                    {
                        xEl.Add(childXmlEl);
                        ConvertJsonToXml1(jP.Value, childXmlEl);
                    }
                }
                else if (jP.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement arrayEl in jP.Value.EnumerateArray())
                    {
                        var childXmlEl = new XElement(jP.Name);
                        if (childXmlEl != null)
                        {
                            xEl.Add(childXmlEl);
                            ConvertJsonToXml1(arrayEl, childXmlEl);
                        }
                    }
                }
                else
                {
                    var childXmlEl = new XElement(jP.Name, jP.Value.GetString());
                    if (childXmlEl != null)
                    {
                        xEl.Add(childXmlEl);
                    }
                }
            }
        }


        static XmlElement ConvertJsonToXml2(JsonElement jE)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement element = xmlDocument.CreateElement(jE.ValueKind.ToString());
            switch (jE.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (JsonProperty property in jE.EnumerateObject())
                    {
                        XmlElement propertyElement = ConvertJsonToXml2(property.Value);
                        propertyElement.SetAttribute("Name", property.Name);
                        element.AppendChild(propertyElement);
                    }
                    break;
                case JsonValueKind.Array:
                    foreach (JsonElement arrayElement in jE.EnumerateArray())
                    {
                        XmlElement arrayItemElement = ConvertJsonToXml2(arrayElement);
                        element.AppendChild(arrayItemElement);
                    }
                    break;
                case JsonValueKind.String:
                    element.InnerText = jE.GetString();
                    break;
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                    element.InnerText = jE.GetRawText();
                    break;
                case JsonValueKind.Null:
                    element.SetAttribute("null", "true");
                    break;
            }
            return element;
        }
    }
}
