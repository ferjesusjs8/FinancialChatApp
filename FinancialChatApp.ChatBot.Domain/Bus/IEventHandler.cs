using FinancialChatApp.ChatBot.Domain.Events;
using System.Threading.Tasks;

namespace FinancialChatApp.ChatBot.Domain.Bus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
