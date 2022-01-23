using System;

namespace FinancialChatApp.Messenger.Domain.Commands
{
    public class ChatMessageSendCommand : Command
    {
        public string ChatRoom { get; protected set; }
        public string UserName { get; protected set; }
        public string ChatMessage { get; protected set; }
        public DateTime SentDate { get; protected set; }
    }
}
