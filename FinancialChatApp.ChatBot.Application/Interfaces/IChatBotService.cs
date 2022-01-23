namespace FinancialChatApp.ChatBot.Application.Interfaces
{
    public interface IChatBotService
    {
        string ParseCode(string code, string chatRoom);
    }
}
