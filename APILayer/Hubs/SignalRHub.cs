using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace APILayer.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly ITableService _tableService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, ITableService tableService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _tableService = tableService;
        }

        public async Task SendStatistics()
        {
            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var activeProductCount = _productService.TActiveProductCount();
            await Clients.All.SendAsync("ReceiveActiveProductCount", activeProductCount);

            var productCountByCategoryNameHamburger = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByCategoryNameHamburger);

            var productCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);

            var productPriceAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg.ToString("0.00" + " ₺"));

            var maxPriceProductName = _productService.TMaxPriceProductName();
            await Clients.All.SendAsync("ReceiveMaxPriceProductName", maxPriceProductName);

            var minPriceProductName = _productService.TMinPriceProductName();
            await Clients.All.SendAsync("ReceiveMinPriceProductName", minPriceProductName);

            var avgHamburgerPrice = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("0.00" + " ₺"));

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00" + " ₺"));

            var moneyCaseAmount = _moneyCaseService.TGetMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", moneyCaseAmount.ToString("0.00" + " ₺"));

            var todayTotalPrice = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice.ToString("0.00" + " ₺"));

            var tableCount = _tableService.TTableCount();
            await Clients.All.SendAsync("ReceiveTableCount", tableCount);
        }

        public async Task SendProgress()
        {
            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var activeProductCount = _productService.TActiveProductCount();
            await Clients.All.SendAsync("ReceiveActiveProductCount", activeProductCount);

            var productCountByCategoryNameHamburger = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByCategoryNameHamburger);

            var productCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);

            var productPriceAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg.ToString("0.00" + " ₺"));

            var maxPriceProductName = _productService.TMaxPriceProductName();
            await Clients.All.SendAsync("ReceiveMaxPriceProductName", maxPriceProductName);

            var minPriceProductName = _productService.TMinPriceProductName();
            await Clients.All.SendAsync("ReceiveMinPriceProductName", minPriceProductName);

            var avgHamburgerPrice = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("0.00" + " ₺"));

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00" + " ₺"));

            var moneyCaseAmount = _moneyCaseService.TGetMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", moneyCaseAmount.ToString("0.00" + " ₺"));

            var todayTotalPrice = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice.ToString("0.00" + " ₺"));

            var tableCount = _tableService.TTableCount();
            await Clients.All.SendAsync("ReceiveTableCount", tableCount);
        }

    }
}
