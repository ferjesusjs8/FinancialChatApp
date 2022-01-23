using FinancialChatApp.Messenger.Application.Interfaces;
using FinancialChatApp.Messenger.Application.Models;
using FinancialChatApp.Messenger.Domain.Bus;
using FinancialChatApp.Messenger.Domain.Commands;
using FinancialChatApp.Messenger.Domain.EventHandlers;
using FinancialChatApp.Messenger.Domain.Events;

namespace FinancialChatApp.Messenger.Application.Services
{
    public class MessengerService : IMessengerService
    {
        private readonly IEventBus _eventBus;
        public MessengerService(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public void GetMessages()
        {
            _eventBus.Subscribe<ChatMessageSendEvent, ChatMessageSendEventHandler>();
        }

        public void PostMessage(MessageDTO message)
        {
            var createChatMessageEvent = new CreateChatMessageSendCommand(message.ChatRoom, message.UserName, message.ChatRoom, message.SentDate);
            _eventBus.SendCommand(createChatMessageEvent);
        }
    }
}
