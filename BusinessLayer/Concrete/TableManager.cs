using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class TableManager : ITableService
    {
        private readonly ITableDal _tableDal;

        public TableManager(ITableDal tableDal)
        {
            _tableDal = tableDal;
        }

        public void TDelete(Table entity)
        {
            throw new NotImplementedException();
        }

        public Table TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Table> TGetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Table> TGetListWhere(Expression<Func<Table, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Table entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Table entity)
        {
            throw new NotImplementedException();
        }
    }
}
