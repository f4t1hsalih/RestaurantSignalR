using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace APILayer.Hubs
{
    public class SignalRHub : Hub
    {
        Context context = new Context();

        public async Task SendCategoryCount()
        {
            var categoryCount = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }
    }
}
