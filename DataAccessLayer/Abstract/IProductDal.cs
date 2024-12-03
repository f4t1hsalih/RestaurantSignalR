using DTOLayer.ProductDto;
using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<GetProductWithCategoryDto> GetProductsWithCategories();
        int ProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        decimal ProductPriceAvg();
        string MinPriceProductName();
        string MaxPriceProductName();

    }
}
