using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface ITableDal : IGenericDal<Table>
    {
        int TableCount();
    }
}
