using System.Collections.Generic;

namespace FinancialChatApp.Presentation.Models.DTO
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChatUser> Users { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}
