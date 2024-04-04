using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HW;
using System.Diagnostics;
using System.ComponentModel.Design;


namespace HW
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Server();
        }

        static void Server()
        {
            UdpClient udpClient = new UdpClient(1234);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Сервер запущен и ждет сообщение от клиента (для завершения работы нажмите Enter)...");
            while (MyClosed())
            {
                byte[] buffer = udpClient.Receive(ref ipEndPoint);
                if (buffer == null) break;
                udpClient.Send(buffer, buffer.Length, ipEndPoint);
                var messageText = Encoding.UTF8.GetString(buffer);
                Message? messageServer = Message.DeserializeFromJsonToMessage(messageText);
                messageServer?.PrintMessage();
            }
        }

        static bool MyClosed()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("До свидания!");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().Kill();
                    return false;
                }
                else return true;
            }
            else return true;
        }
    }
}







