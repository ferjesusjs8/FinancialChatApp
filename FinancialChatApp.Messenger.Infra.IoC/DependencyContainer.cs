using FinancialChatApp.Messenger.Application.Interfaces;
using FinancialChatApp.Messenger.Application.Services;
using FinancialChatApp.Messenger.Domain.Bus;
using FinancialChatApp.Messenger.Domain.CommandHandlers;
using FinancialChatApp.Messenger.Domain.Commands;
using FinancialChatApp.Messenger.Domain.EventHandlers;
using FinancialChatApp.Messenger.Domain.Events;
using FinancialChatApp.Messenger.Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialChatApp.Messenger.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            // Subscriptions
            services.AddTransient<ChatMessageSendEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<ChatMessageSendEvent>, ChatMessageSendEventHandler>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateChatMessageSendCommand, bool>, ChatMessageSendCommandHandler>();

            // Domain Transfer Commands


            // Application Services
            services.AddTransient<IMessengerService, MessengerService>();
        }
    }
}
