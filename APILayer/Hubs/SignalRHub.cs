using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace APILayer.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public SignalRHub(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public async Task SendCategoryCount()
        {
            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }
        public async Task SendActiveCategoryCount()
        {
            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);
        }
        public async Task SendPassiveCategoryCount()
        {
            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);
        }

        public async Task SendActiveProductCount()
        {
            var activeProductCount = _productService.TActiveProductCount();
            await Clients.All.SendAsync("ReceiveActiveProductCount", activeProductCount);
        }

    }
}
