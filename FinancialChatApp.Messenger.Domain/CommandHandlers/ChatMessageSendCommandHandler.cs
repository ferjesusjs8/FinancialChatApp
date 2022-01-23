using FinancialChatApp.Messenger.Domain.Bus;
using FinancialChatApp.Messenger.Domain.Commands;
using FinancialChatApp.Messenger.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FinancialChatApp.Messenger.Domain.CommandHandlers
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
