using FinancialChatApp.ChatBot.Application.Interfaces;
using FinancialChatApp.ChatBot.Domain.Bus;
using FinancialChatApp.ChatBot.Domain.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FinancialChatApp.ChatBot.Application.Services
{
    public class ChatBotService : IChatBotService
    {
        private readonly IEventBus _eventBus;
        private readonly WebClient _apiClient;

        public ChatBotService(IEventBus eventBus)
        {
            _eventBus = eventBus;
            _apiClient = new WebClient();
        }

        public string ParseCode(string code, string chatRoom)
        {
            var file = $"{code}{DateTime.UtcNow.ToString("MM_dd_yyyy").Replace('/', '_')}.csv";

            GetCSV(code, file);
            var message = RetrieveParsedCode(code, file);

            var createTransferCommand =
                new CreateChatMessageSendCommand(
                    chatRoom,
                    "Chat_Bot",
                    message,
                    DateTime.UtcNow);

            _eventBus.SendCommand(createTransferCommand);

            return message;
        }

        private void GetCSV(string code, string file)
        {
            var uri = $"https://stooq.com/q/l/?s={code}&f=sd2t2ohlcv&h&e=csv";

            _apiClient.DownloadFile(uri, file);
        }

        private string RetrieveParsedCode(string code, string file)
        {
            var fileContent = File.ReadAllText(file);

            var values = new List<string>();

            if (fileContent.Contains(','))
            {
                values = fileContent.Split(',').ToList();
            }
            else
            {
                values = fileContent.Split(';').ToList();
            }

            var result = values[values.Count - 2];

            if (result.Contains("N/D"))
            {
                return $"The code '{code}' is invalid and could not be found. Please check the correct code and send it again.";
            }

            File.Delete(file);

            return $"{code.ToUpper()} quote is {result} per share.";
        }
    }
}
