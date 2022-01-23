using FinancialChatApp.ChatBot.Domain.Events;
using System;

namespace FinancialChatApp.ChatBot.Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        public Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
