using FinancialChatApp.ChatBot.Application.Interfaces;
using FinancialChatApp.ChatBot.Application.Services;
using FinancialChatApp.ChatBot.Domain.Bus;
using FinancialChatApp.ChatBot.Domain.CommandHandlers;
using FinancialChatApp.ChatBot.Domain.Commands;
using FinancialChatApp.ChatBot.Infra.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialChatApp.ChatBot.Infra.IoC
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

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateChatMessageSendCommand, bool>, ChatMessageSendCommandHandler>();

            // Domain Transfer Commands


            // Application Services
            services.AddTransient<IChatBotService, ChatBotService>();
        }
    }
}
