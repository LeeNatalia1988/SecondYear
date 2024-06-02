using MessageWorker.DbModels;

namespace MessageWorker.DTO
{
    public class MessageViewModelToSend
    {
        public string Text { get; set; }
                
        public string ToUser { get; set; }
    }
}
