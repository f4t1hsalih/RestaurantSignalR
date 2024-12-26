using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    internal class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(Context context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableNumber(int tableNumber)
        {
            return _context.Baskets.Where(x => x.TableId == tableNumber).ToList();
        }
    }
}
