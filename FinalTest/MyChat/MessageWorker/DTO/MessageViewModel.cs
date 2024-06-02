using MessageWorker.DbModels;

namespace MessageWorker.DTO
{
    public class MessageViewModel
    {
        public string FromUser { get; set; }    
        public string ToUser { get; set; }
        public string Text { get; set; }
        public MessageStatus MessageStatus { get; set; }
    }
}
