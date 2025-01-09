using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface ITableDal : IGenericDal<Table>
    {
        int TableCount();
        void ChangeTableStatusToTrue(int tableId);
        void ChangeTableStatusToFalse(int tableId);
    }
}
