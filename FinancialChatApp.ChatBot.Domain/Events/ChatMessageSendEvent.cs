using System;

namespace FinancialChatApp.ChatBot.Domain.Events
{
    public class ChatMessageSendEvent : Event
    {
        public string ChatRoom { get; private set; }
        public string UserName { get; private set; }
        public string ChatMessage { get; private set; }
        public DateTime SentDate { get; private set; }

        public ChatMessageSendEvent(string chatRoom, string chatMessage, string userName, DateTime sentDate)
        {
            ChatRoom = chatRoom;
            UserName = userName;
            ChatMessage = chatMessage;
            SentDate = sentDate;
        }
    }
}
