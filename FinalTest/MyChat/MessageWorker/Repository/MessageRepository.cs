using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;
using MessageWorker.Abstractions;
using MessageWorker.DbModels;
using MessageWorker.DTO;
using MessageWorker.Db;
using Microsoft.Extensions.Primitives;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Helpers;

namespace MessageWorker.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private IMapper _mapper;
        public MessageRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void SendMessage(MessageViewModelToSend messageViewModel, string fromUser)
        {
            using (var context = new MessageContext())
            {
                var entity = new Message();
                entity.FromUser = fromUser;
                entity.ToUser = messageViewModel.ToUser.Replace(@"""", "");
                entity.Text = messageViewModel.Text;
                entity.StatusID = 0;
                context.Messages.Add(entity);
                context.SaveChanges();
            }
        }

        public List<string> ReceiveMessage(string toUser)
        {
            var messages = new List<String>();
            
            using (var context = new MessageContext())
            {
                foreach (var m in context.Messages)
                {
                    if (m.ToUser == toUser && m.StatusID == 0)
                    {
                        messages.Add("От: " + m.FromUser + "     Текст: " + m.Text);
                        m.StatusID = MessageStatusID.Receive;
                    }
                }
                context.SaveChanges();
            }
            return messages;
        }
    }
}

