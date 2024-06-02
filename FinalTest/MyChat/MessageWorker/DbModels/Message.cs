namespace MessageWorker.DbModels
{
    public class Message
    {
        public Guid? Id { get; set; }
        public string Text { get; set; }

        public string FromUser { get; set; }

        public string ToUser { get; set; }

        public MessageStatusID StatusID { get; set; }
        public virtual MessageStatus MessageStatus { get; set; }
    }
}
