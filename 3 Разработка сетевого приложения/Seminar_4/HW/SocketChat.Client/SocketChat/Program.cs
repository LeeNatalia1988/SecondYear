using System.Diagnostics;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using System.Threading;
using System;

using SocketChat.Common.Entities;
using System.Xml.Linq;

namespace SocketChat.Client
{
    internal class Program
    {
        public static void Main()
        {
            HubConnection connection;
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7217/chat").Build();
            SignalRMessage message = new SignalRMessage();
            
            if (Connect(connection).Result)
            {
                Console.WriteLine("Введите ваше имя:");
                message.FromUser = Console.ReadLine() ?? "UnknowUser";
                connection.On<string>("Receive", (messageText) =>
                {
                    Console.WriteLine(messageText);
                });
                Console.WriteLine("Введите сообщение или ex для выхода: ");
                while (true)
                {
                    Send(connection, message);
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

        static async void Send(HubConnection connection, SignalRMessage message)
        {

            do
            {
                message.Message = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(message.Message));

            if (message.Message == "ex")
            {
                Console.WriteLine("До свидания!");
                Thread.Sleep(1000);
                message.Message = "покинул чат";
                await connection.InvokeAsync("Send", message);
                await connection.StopAsync();
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                try
                {
                    await connection.InvokeAsync("Send", message);
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message);
                }
            }
        }
    }
}

