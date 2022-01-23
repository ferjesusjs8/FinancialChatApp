using FinancialChatApp.ChatBot.Domain.Bus;
using FinancialChatApp.ChatBot.Domain.Commands;
using FinancialChatApp.ChatBot.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialChatApp.ChatBot.Domain.CommandHandlers
{
    public class ChatMessageSendCommandHandler : IRequestHandler<CreateChatMessageSendCommand, bool>
    {
        private readonly IEventBus _eventBus;

        public ChatMessageSendCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateChatMessageSendCommand request, CancellationToken cancellationToken)
        {
            // publish event to RabbitMQ
            _eventBus.Publish(
                new ChatMessageSendEvent(
                    request.ChatRoom,
                    request.ChatMessage,
                    request.UserName,
                    request.SentDate));

            return Task.FromResult(true);
        }
    }
}
