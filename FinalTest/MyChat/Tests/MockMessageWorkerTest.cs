using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageWorker.Abstractions;
using MessageWorker.Db;
using MessageWorker.DbModels;
using MessageWorker.DTO;
using MessageWorker.Repository;


namespace Tests
{
    internal class MockMessageWorkerTest : IMessageRepository
    {
        public List<string> ReceiveMessage(string userName)
        {
            var messages = new List<String>();

            using (var context = new MessageContext())
            {
                foreach (var m in context.Messages)
                {
                    if (m.ToUser == userName && m.StatusID == 0)
                    {
                        messages.Add("От: " + m.FromUser + "\nТекст: " + m.Text);
                        m.StatusID = MessageStatusID.Receive;
                    }
                }
                context.SaveChanges();
            }
            return messages;
        }

        public void SendMessage(MessageViewModelToSend messageViewModel, string fromUser)
        {
            using (var context = new MessageContext())
            {
                var entity = new Message();
                entity.FromUser = fromUser;
                entity.ToUser = messageViewModel.ToUser;
                entity.Text = messageViewModel.Text;
                entity.StatusID = 0;
                context.Messages.Add(entity);
                context.SaveChanges();
                Task.Delay(2000);
            }
        }
    }
}
