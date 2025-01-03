﻿using DTOLayer.ProductDto;
using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        List<GetProductWithCategoryDto> GetProductsWithCategories();
        List<GetProductWithCategoryDto> GetProductsWithCategoriesFirstNine();
        int ProductCount();
        int ActiveProductCount();
        int ProductCountByCategoryNameHamburger();
        int ProductCountByCategoryNameDrink();
        decimal ProductPriceAvg();
        string MinPriceProductName();
        string MaxPriceProductName();
        decimal ProductAvgPriceByHamburger();

    }
}
