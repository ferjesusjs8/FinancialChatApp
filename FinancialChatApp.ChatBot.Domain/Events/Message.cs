using MediatR;

namespace FinancialChatApp.ChatBot.Domain.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}
