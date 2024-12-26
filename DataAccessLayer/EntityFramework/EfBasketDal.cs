using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DTOLayer.BasketDto;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(Context context) : base(context)
        {
        }

        public List<Basket> GetBasketByTableNumber(int tableNumber)
        {
            return _context.Baskets.Where(x => x.TableId == tableNumber).ToList();
        }

        public List<ResultBasketWithProductNamesDto> GetBasketByTableNumberWithProductNames(int tableNumber)
        {
            return _context.Baskets
                .Where(x => x.TableId == tableNumber)
                .Select(x => new ResultBasketWithProductNamesDto
                {
                    BasketId = x.BasketId,
                    TableName = x.Tables.Name,
                    ProductName = x.Products.Name,
                    Count = x.Count,
                    Price = x.Price,
                    TotalPrice = x.TotalPrice,
                })
                .ToList();
        }
    }
}
