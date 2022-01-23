using FinancialChatApp.Messenger.Application.Models;
using System.Collections.Generic;

namespace FinancialChatApp.Messenger.Application.Interfaces
{
    public interface IMessengerService
    {
        void GetMessages();
        void PostMessage(MessageDTO message);
    }
}
