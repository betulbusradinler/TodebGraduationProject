namespace DTO.Chat
{
    public class CreateChatRegisterRequest
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReciverMail { get; set; }
        public string SenderMail { get; set; }
    }
}
