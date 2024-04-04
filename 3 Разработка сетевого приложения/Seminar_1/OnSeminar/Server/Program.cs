using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace OnSeminar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(1234);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Сервер ждет сообщение от клиента...");

            while (Console.ReadKey() == null)
            {
                byte[] buffer = udpClient.Receive(ref ipEndPoint);
                if (buffer == null) break;
                var messageText = Encoding.UTF8.GetString(buffer);
                Message? messageServer = Message.DeserializeFromJsonToMessage(messageText);
                messageServer?.PrintMessage();
                Console.WriteLine("Для завершения работы нажмите любую клавишу...");
            }
        }
    }
}
