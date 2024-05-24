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

namespace ChatApp
{
    public class ChatClient
    {
        private readonly string _nameClient;
        private readonly IMessageSource _messageSource;
        private readonly IPEndPoint _serverEndPoint;
        private bool _isWork = true;

        public ChatClient(string nameClient, IMessageSource messageSource)
        {
            //_nameClient = Registration();
            _nameClient = nameClient;
            _messageSource = messageSource;
            _serverEndPoint = messageSource.GetServerIPEndPoint();
        }

        public void ProcessSendMessage()
        {
            while (_isWork)
            {
                Console.WriteLine("Введите имя получателя или ex для выхода: ");
                var receive = Console.ReadLine();
                if (receive != "ex")
                {
                    Console.WriteLine("Введите сообщение или ex для выхода:");
                    var text = Console.ReadLine();
                    if (text != "ex")
                    {
                        var chatMessage = new ChatMessage() 
                            { Command = Command.Message, FromName = _nameClient, ToName = receive, Text = text };
                        _messageSource.SendMessage(chatMessage, _serverEndPoint);
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

        public void ProcessReceiveMessage()
        {
            var ipEndPoint = _messageSource.GetServerIPEndPoint();
            while (_isWork)
            {
                var data = _messageSource.ReceiveMessage(ref ipEndPoint);
                Console.WriteLine($"Получено сообщение от {data.FromName}: \n{data.Text}");
                Confirmation(data, ipEndPoint);
            }
        }

        public void Work()
        {
            //Registration();
            new Thread(() => ProcessSendMessage()).Start();
            new Thread(() => ProcessReceiveMessage()).Start();
        }

        /*public void Registration()
        {
            /*Console.WriteLine("Введите свое имя: ");
            if(Console.ReadLine() != null)
            {
                return Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Вы не представились, повторите: ");
                return Registration();
            }

            var register = new ChatMessage() { Command = Command.Register, FromName = _nameClient };
            _messageSource.SendMessage(register, _serverEndPoint);
        }*/

        public void Confirmation(ChatMessage chatMessage, IPEndPoint ipEndPoint)
        {
            var message = new ChatMessage() { Command = Command.Confirmation, Id = chatMessage.Id };
            _messageSource.SendMessage(message, ipEndPoint);
        }

        public void Stop()
        {
            _isWork = false;
            Console.WriteLine("До свидания!");
            Thread.Sleep(1000);
            Process.GetCurrentProcess().Kill();
        }
    }
}