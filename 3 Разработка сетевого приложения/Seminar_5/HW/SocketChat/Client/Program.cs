using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Xml.Linq;
using SocketChat.Common.Entities;

namespace SocketChat.Client
{
    internal class Program
    {
        public static void Main()
        {
            HubConnection connection;
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7217/chat").Build();
            SignalRMessage message = new SignalRMessage();
            User user = new User();

            if (Connect(connection).Result)
            {
                Console.WriteLine("Введите ваше имя:");
                user.Name = Console.ReadLine() ?? "UnknowUser";
                connection.On<string>("Receive", (messageText) =>
                {
                    Console.WriteLine(messageText);
                });
                Console.WriteLine("Введите сообщение или ex для выхода: ");
                while (true)
                {
                    Send(connection, message, user);
                }
            }
        }
        static async Task<bool> Connect(HubConnection connection)
        {
            try
            {
                await connection.StartAsync();
                await Console.Out.WriteLineAsync("Вы вошли в чат.");
                return true;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return false;
            }
        }

        static async void Send(HubConnection connection, SignalRMessage message, User user)
        {
            do
            {
                message.MessageText = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(message.MessageText));

            if (message.MessageText == "ex")
            {
                Console.WriteLine("До свидания!");
                Thread.Sleep(1000);
                message.MessageText = "покинул чат";
                await connection.InvokeAsync("Send", message, user);
                await connection.StopAsync();
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                try
                {
                    await connection.InvokeAsync("Send", message, user);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
        }
    }
}

