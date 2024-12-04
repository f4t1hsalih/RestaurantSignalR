using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(Context context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            return _context.Orders.Count(x => x.Description == "Müşteri Masada");
        }

        public decimal LastOrderPrice()
        {
            var lastOrder = _context.Orders.OrderByDescending(x => x.Date).FirstOrDefault();
            return lastOrder?.TotalPrice ?? 0m;  // Null kontrolü ekledik, eğer sipariş yoksa 0 döner.
        }

        public decimal TodayTotalPrice()
        {
            return _context.Orders.Where(x => x.Date.Date == System.DateTime.Now.Date).Sum(x => x.TotalPrice);
        }

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}
