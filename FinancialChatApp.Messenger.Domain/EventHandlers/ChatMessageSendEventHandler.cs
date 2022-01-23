using FinancialChatApp.Messenger.Domain.Bus;
using FinancialChatApp.Messenger.Domain.Commands;
using FinancialChatApp.Messenger.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChatApp.Messenger.Domain.EventHandlers
{
    public class ChatMessageSendEventHandler : IEventHandler<ChatMessageSendEvent>
    {
        private readonly IEventBus _eventBus;

        public ChatMessageSendEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task Handle(ChatMessageSendEvent @event)
        {
            var createChatMessageSendCommand = new CreateChatMessageSendCommand(@event.ChatRoom, @event.UserName, @event.ChatMessage, @event.SentDate);

            _eventBus.SendCommand(createChatMessageSendCommand);

            return Task.CompletedTask;
        }
    }
}
