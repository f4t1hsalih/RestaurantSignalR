using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetListAll();
        List<T> GetListWhere(Expression<Func<T, bool>> predicate);
        T GetById(int id);
    }
}
