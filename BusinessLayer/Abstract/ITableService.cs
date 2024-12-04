using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface ITableService : IGenericService<Table>
    {
        int TTableCount();
    }
}
