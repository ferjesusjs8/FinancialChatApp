using System;

namespace FinancialChatApp.Messenger.Domain.Events
{
    public abstract class Event
    {
        public DateTime Timestamp { get; protected set; }

        public Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}
