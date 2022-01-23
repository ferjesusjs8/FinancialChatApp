using FinancialChatApp.Messenger.Domain.Events;
using System;

namespace FinancialChatApp.Messenger.Domain.Commands
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
