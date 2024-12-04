using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfMoneyCaseDal : GenericRepository<MoneyCase>, IMoneyCaseDal
    {
        public EfMoneyCaseDal(Context context) : base(context)
        {
        }

        public decimal GetMoneyCaseAmount()
        {
            return _context.MoneyCases.Sum(x => x.TotalAmount);
        }
    }
}
