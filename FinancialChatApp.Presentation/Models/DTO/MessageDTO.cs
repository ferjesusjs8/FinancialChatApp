using System;

namespace FinancialChatApp.Presentation.Models.DTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public DateTime SentDate { get; set; }
        public string ChatRoom { get; set; }
    }
}
