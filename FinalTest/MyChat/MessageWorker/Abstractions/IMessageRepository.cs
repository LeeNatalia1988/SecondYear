using MessageWorker.DbModels;
using MessageWorker.DTO;

namespace MessageWorker.Abstractions
{
    public interface IMessageRepository
    {
        public void SendMessage(MessageViewModelToSend messageViewModel, string fromUser);
        public List<string> ReceiveMessage(string userName);
        
        
    }
}
