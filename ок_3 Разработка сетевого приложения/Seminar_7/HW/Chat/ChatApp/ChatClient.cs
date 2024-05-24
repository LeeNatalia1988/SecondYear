using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ChatNetwork;
using CommonChat.DTO;
using CommonChat.Model;
using static System.Net.Mime.MediaTypeNames;

namespace ChatApp
{
    public class ChatClient
    {
        private readonly string _name;
        private readonly IMessageSource _messageSource;
        private readonly IPEndPoint _serverEndPoint;
        private bool _isWork = true;
        public ChatClient(string name, IMessageSource messageSource)
        {
            _name = name;
            _messageSource = messageSource;
            _serverEndPoint = messageSource.GetServerIPEndPoint();
        }

        public void SendMessage(ChatMessage chatMessage, IPEndPoint ip)
        {
            _messageSource.SendMessage(chatMessage, ip);
        }

        public void Register()
        {
            var registerChat = new ChatMessage() { Command = Command.Register, FromName = _name};
            _messageSource.SendMessage(registerChat, _serverEndPoint);
        }

        public void Stop()
        {
            _isWork = false;

            var chatMessage = new ChatMessage()
            { Command = Command.Message, FromName = _name, Text = "Пользователь вышел из чата." };
            SendMessage(chatMessage, _serverEndPoint);

            Console.WriteLine("До свидания!");
            Thread.Sleep(1000);
            Process.GetCurrentProcess().Kill();
        }

        public void ProcessSendMessage()
        {
            while (true)
            {
                Console.WriteLine("Input receiver's name or ex for exit: ");
                var receiver = Console.ReadLine();
                if (receiver != "ex")
                {
                    Console.WriteLine("Input your message or ex for exit: ");
                    var text = Console.ReadLine();
                    if (text != "ex")
                    {
                        var chatMessage = new ChatMessage()
                        { Command = Command.Message, FromName = _name, ToName = receiver, Text = text };

                        SendMessage(chatMessage, _serverEndPoint);
                    }
                    else
                    {
                        Stop();
                    }
                }
                else
                {
                    Stop();
                }
            }
        }

        public void Listen()
        {
            var ip = _messageSource.CreateNewIPEndPoint();
            Register();
            while (_isWork)
            {
                var data = _messageSource.Receive(ref ip);
                Console.WriteLine($"Сообщение получено от {data.FromName}: \n{data.Text}");
                Confirmation(data, ip);
            }
        }

        public void Confirmation(ChatMessage chatMessage, IPEndPoint ip)
        {
            var message = new ChatMessage() {Command = Command.Confirmation, Id = chatMessage.Id};
            SendMessage(message, ip);
        }

        public void Start()
        {
            new Thread(() => ProcessSendMessage()).Start();
            Listen();
        }
    }
}