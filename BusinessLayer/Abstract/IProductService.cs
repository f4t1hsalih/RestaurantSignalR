using DTOLayer.ProductDto;
using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<GetProductWithCategoryDto> TGetProductsWithCategories();
        int TProductCount();
        int TActiveProductCount();
        int TProductCountByCategoryNameHamburger();
        int TProductCountByCategoryNameDrink();
        decimal TProductPriceAvg();
        string TMaxPriceProductName();
        string TMinPriceProductName();
        decimal TProductAvgPriceByHamburger();

    }
}
