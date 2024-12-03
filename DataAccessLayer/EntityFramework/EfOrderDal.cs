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

        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}
