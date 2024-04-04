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
        public static async Task Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(MyClosed));
            Thread t2 = new Thread(new ThreadStart(Server));
            t1.Start();
            t2.Start();


        }

        static void Server()
        {
            UdpClient udpClient = new UdpClient(1234);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Сервер запущен и ждет сообщение от клиента (для завершения работы нажмите Enter)...");
            while (true)
            {
                byte[] buffer = udpClient.Receive(ref ipEndPoint);
                udpClient.Send(buffer, buffer.Length, ipEndPoint);
                var messageText = Encoding.UTF8.GetString(buffer);
                Message? messageServer = Message.DeserializeFromJsonToMessage(messageText);
                messageServer?.PrintMessage();
            }
        }

        static void MyClosed()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("До свидания!");
                        Thread.Sleep(1000);
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
        }
    }
}







