using System;

namespace FinancialChatApp.ChatBot.Domain.Commands
{
    public class CreateChatMessageSendCommand : ChatMessageSendCommand
    {
        public CreateChatMessageSendCommand(string chatRoom, string userName, string chatMessage, DateTime sentDate)
        {
            ChatRoom = chatRoom;
            UserName = userName;
            ChatMessage = chatMessage;
            SentDate = sentDate;
        }
    }
}
