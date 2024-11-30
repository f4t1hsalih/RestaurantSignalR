using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace APILayer.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly Context _context;

        public SignalRHub(Context context)
        {
            _context = context;
        }

        public async Task SendCategoryCount()
        {
            var categoryCount = _context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }
    }
}
