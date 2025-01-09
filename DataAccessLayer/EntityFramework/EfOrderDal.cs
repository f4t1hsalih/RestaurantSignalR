using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

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

        public bool CompleteOrderByTableId(int tableId)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Tetikleyiciyi devre dışı bırak
                _context.Database.ExecuteSqlRaw("DISABLE TRIGGER [SumMoneyCases] ON [Orders]");

                var order = _context.Orders.FirstOrDefault(x => x.TableId == tableId && x.Description == "Müşteri Masada");
                if (order != null)
                {
                    order.Description = "Hesap Kapatıldı";
                    order.Date = DateTime.Now;
                    order.TotalPrice = 0;
                }

                var table = _context.Tables.FirstOrDefault(x => x.TableId == tableId);
                if (table != null)
                {
                    table.Status = false;
                }

                _context.SaveChanges();

                // Tetikleyiciyi tekrar etkinleştir
                _context.Database.ExecuteSqlRaw("ENABLE TRIGGER [SumMoneyCases] ON [Orders]");

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
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
