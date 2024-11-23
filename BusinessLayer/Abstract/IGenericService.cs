using System.Linq.Expressions;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T entity);
        void TDelete(T entity);
        void TUpdate(T entity);
        List<T> TGetListAll();
        List<T> TGetListWhere(Expression<Func<T, bool>> predicate);
        T TGetById(int id);
    }
}
