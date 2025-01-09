using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;

namespace DataAccessLayer.EntityFramework
{
    public class EfTableDal : GenericRepository<Table>, ITableDal
    {
        public EfTableDal(Context context) : base(context)
        {
        }

        public void ChangeTableStatusToFalse(int tableId)
        {
            _context.Tables.Find(tableId).Status = false;
            _context.SaveChanges();
        }

        public void ChangeTableStatusToTrue(int tableId)
        {
            _context.Tables.Find(tableId).Status = true;
            _context.SaveChanges();
        }

        public int TableCount()
        {
            return _context.Tables.Count();
        }
    }
}
