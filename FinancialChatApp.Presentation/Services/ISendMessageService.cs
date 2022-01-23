using FinancialChatApp.Presentation.Models.DTO;
using System.Threading.Tasks;

namespace FinancialChatApp.Presentation.Services
{
    public interface ISendMessageService
    {
        Task Send(MessageDTO messageModel);
    }
}
