using PrismTabs.Services.Interfaces;

namespace PrismTabs.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
