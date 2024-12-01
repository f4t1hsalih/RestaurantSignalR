﻿using DTOLayer.ProductDto;
using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<GetProductWithCategoryDto> TGetProductsWithCategories();
    }
}
