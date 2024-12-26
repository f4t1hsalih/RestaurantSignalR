using DTOLayer.BasketDto;
using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<Basket> TGetBasketByTableNumber(int tableNumber);
        List<ResultBasketWithProductNamesDto> TGetBasketByTableNumberWithProductNames(int tableNumber);

    }
}
