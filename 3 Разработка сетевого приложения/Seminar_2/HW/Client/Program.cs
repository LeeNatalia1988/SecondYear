using System.Net.Sockets;
using System.Net;
using System.Text;
using HW;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;


namespace HW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(args[1]), 1234);


            while (true)
            {
                string? messageText;
                do
                {
                    Console.WriteLine("Введите сообщение или ex для выхода: ");
                    messageText = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(messageText));
                if (messageText == "ex")
                {
                    Console.WriteLine("До свидания!");
                    Thread.Sleep(1000);
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Message message = new Message() { Text = messageText, DateTime = DateTime.Now, NickNameFrom = args[0], NickNameTo = "Server" };
                    string json = message.SerializeMessageToJson();
                    byte[] data = Encoding.UTF8.GetBytes(json);
                    udpClient.Send(data, data.Length, ipEndPoint);
                    Thread.Sleep(2000);
                    try
                    {
                        byte[] buffer = udpClient.Receive(ref ipEndPoint);
                        var messageText1 = Encoding.UTF8.GetString(buffer);
                        Message? messageServer = Message.DeserializeFromJsonToMessage(messageText1);
                        messageServer?.PrintMessage();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Сообщение потерялось или сервер вам отказал...\n{e.Message}");
                    }
                }
            }
        }
    }
}


