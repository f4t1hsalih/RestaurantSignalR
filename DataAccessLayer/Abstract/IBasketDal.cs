using DTOLayer.BasketDto;
using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IBasketDal : IGenericDal<Basket>
    {
        List<Basket> GetBasketByTableNumber(int tableNumber);
        List<ResultBasketWithProductNamesDto> GetBasketByTableNumberWithProductNames(int tableNumber);
    }
}
