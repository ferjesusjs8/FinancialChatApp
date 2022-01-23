using FinancialChatApp.Presentation.Models.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChatApp.Presentation.Services
{
    public class SendMessageService : ISendMessageService
    {
        private readonly HttpClient _apiClient;
        public SendMessageService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Send(MessageDTO messageModel)
        {
            var uri = "https://localhost:5001/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(messageModel), Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync(uri, transferContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
