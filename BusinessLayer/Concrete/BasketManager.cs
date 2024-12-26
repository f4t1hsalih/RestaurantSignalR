using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.BasketDto;
using EntityLayer.Entities;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IBasketDal _basketDal;

        public BasketManager(IBasketDal basketDal)
        {
            _basketDal = basketDal;
        }

        public void TDelete(Basket entity)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetBasketByTableNumber(int tableNumber)
        {
            return _basketDal.GetBasketByTableNumber(tableNumber);
        }

        public List<ResultBasketWithProductNamesDto> TGetBasketByTableNumberWithProductNames(int tableNumber)
        {
            return _basketDal.GetBasketByTableNumberWithProductNames(tableNumber);
        }

        public Basket TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Basket> TGetListWhere(Expression<Func<Basket, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Basket entity)
        {
            _basketDal.Insert(entity);
        }

        public void TUpdate(Basket entity)
        {
            throw new NotImplementedException();
        }
    }
}
