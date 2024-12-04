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
    }
}
