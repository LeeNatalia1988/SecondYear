using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Server;

namespace OnSeminar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string ip = args[1];
            string from = args[0];
            UdpClient udpClient = new UdpClient();
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), 1234);


            while (true)
            {
                string? messageText;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Введите сообщение или exit для выхода: ");
                    messageText = Console.ReadLine();
                }
                while ((string.IsNullOrEmpty(messageText)) && (messageText != "exit"));

                Message message = new Message() { Text = messageText, DateTime = DateTime.Now, NickNameFrom = from, NickNameTo = "Server" };
                string json = message.SerializeMessageToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, ipEndPoint);
            }
        }
    }
}
