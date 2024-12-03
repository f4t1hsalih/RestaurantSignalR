using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DTOLayer.ProductDto;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public List<GetProductWithCategoryDto> GetProductsWithCategories()
        {
            var values = _context.Products.Include(x => x.Categories).Select(x => new GetProductWithCategoryDto
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                ImageUrl = x.ImageUrl,
                Status = x.Status,
                CategoryName = x.Categories.Name
            }).ToList();
            return values;
        }

        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            return _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(y => y.Name == "İçecek").Select(z=>z.CategoryId)).FirstOrDefault()).Count();
        }

        public int ProductCountByCategoryNameHamburger()
        {
            return _context.Products.Count(x => x.Categories.Name == "Hamburger");
        }
    }
}
