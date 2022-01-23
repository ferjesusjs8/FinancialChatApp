using System;

namespace FinancialChatApp.ChatBot.Domain.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public DateTime SentDate { get; set; }
        public string ChatRoom { get; set; }
    }
}
