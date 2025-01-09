using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface ITableService : IGenericService<Table>
    {
        int TTableCount();
        void TChangeTableStatusToTrue(int tableId);
        void TChangeTableStatusToFalse(int tableId);
    }
}
