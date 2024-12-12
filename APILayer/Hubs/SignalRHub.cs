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
            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);
        }

        public async Task SendProductCount()
        {
            var activeProductCount = _productService.TActiveProductCount();
            await Clients.All.SendAsync("ReceiveActiveProductCount", activeProductCount);
        }

    }
}
