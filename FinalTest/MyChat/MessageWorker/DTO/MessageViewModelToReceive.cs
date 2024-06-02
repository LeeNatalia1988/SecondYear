using MessageWorker.DbModels;

namespace MessageWorker.DTO
{
    public class MessageViewModelToReceive
    {
        public string Text { get; set; }

        public string FromUser { get; set; }
        
    }
}
