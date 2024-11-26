using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.ProductDto;
using EntityLayer.Entities;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<GetProductWithCategoryDto> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public List<Product> TGetListWhere(Expression<Func<Product, bool>> predicate)
        {
            return _productDal.GetListWhere(predicate);
        }

        public void TInsert(Product entity)
        {
            _productDal.Insert(entity);
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
