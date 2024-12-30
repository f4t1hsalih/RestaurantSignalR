using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace APILayer.Hubs
{
    public class SignalRHub : Hub
    {
        public static int clientCount { get; set; } = 0;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly ITableService _tableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, ITableService tableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _tableService = tableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }

        public async Task SendStatistics()
        {
            // Kategori Sayısı
            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            // Aktif Kategori Sayısı
            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            // Pasif Kategori Sayısı
            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            // Aktif Ürün Sayısı
            var activeProductCount = _productService.TActiveProductCount();
            await Clients.All.SendAsync("ReceiveActiveProductCount", activeProductCount);

            // Hamburger Kategorisindeki Ürün Sayısı
            var productCountByCategoryNameHamburger = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", productCountByCategoryNameHamburger);

            // İçecek Kategorisindeki Ürün Sayısı
            var productCountByCategoryNameDrink = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", productCountByCategoryNameDrink);

            // Ürünlerin Ortalama Fiyatı
            var productPriceAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", productPriceAvg.ToString("0.00" + " ₺"));

            // En Pahalı Ürünün Adı
            var maxPriceProductName = _productService.TMaxPriceProductName();
            await Clients.All.SendAsync("ReceiveMaxPriceProductName", maxPriceProductName);

            // En Ucuz Ürünün Adı
            var minPriceProductName = _productService.TMinPriceProductName();
            await Clients.All.SendAsync("ReceiveMinPriceProductName", minPriceProductName);

            // Hamburger Kategorisindeki Ürünlerin Ortalama Fiyatı
            var avgHamburgerPrice = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAvgHamburgerPrice", avgHamburgerPrice.ToString("0.00" + " ₺"));

            // Toplam Sipariş Sayısı
            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            // Aktif Sipariş Sayısı
            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            // Son Sipariş Fiyatı
            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00" + " ₺"));

            // Kasa Miktarı
            var moneyCaseAmount = _moneyCaseService.TGetMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", moneyCaseAmount.ToString("0.00" + " ₺"));

            // Bugünkü Toplam Satış Fiyatı
            var todayTotalPrice = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice.ToString("0.00" + " ₺"));

            // Masa Sayısı
            var tableCount = _tableService.TTableCount();
            await Clients.All.SendAsync("ReceiveTableCount", tableCount);
        }

        public async Task SendProgress()
        {
            // Aktif Sipariş Sayısı
            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            // Kasa Miktarı
            var moneyCaseAmount = _moneyCaseService.TGetMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveMoneyCaseAmount", moneyCaseAmount.ToString("0.00" + " ₺"));

            // Bugünkü Toplam Satış Fiyatı
            var todayTotalPrice = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice.ToString("0.00" + " ₺"));

        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }

        public async Task SendNotification()
        {
            var value = _notificationService.TGetNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCount", value);

            var notifications = _notificationService.TGetNotificationsByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationList", notifications);
        }

        public async Task GetTableStatus()
        {
            var values = _tableService.TGetListAll();
            await Clients.All.SendAsync("ReceiveTableList", values);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
