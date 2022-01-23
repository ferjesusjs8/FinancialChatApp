using System;

namespace FinancialChatApp.Presentation.Models.DTO
{
    public class ChatUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime LastMessage { get; set; }
        public bool IsActive { get; set; }
    }
}
