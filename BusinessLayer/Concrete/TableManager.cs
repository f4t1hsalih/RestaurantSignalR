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

        public int TTableCount()
        {
            return _tableDal.TableCount();
        }

        public void TDelete(Table entity)
        {
            _tableDal.Delete(entity);
        }

        public Table TGetById(int id)
        {
            return _tableDal.GetById(id);
        }

        public List<Table> TGetListAll()
        {
            return _tableDal.GetListAll();
        }

        public List<Table> TGetListWhere(Expression<Func<Table, bool>> predicate)
        {
            return _tableDal.GetListWhere(predicate);
        }

        public void TInsert(Table entity)
        {
            _tableDal.Insert(entity);
        }

        public void TUpdate(Table entity)
        {
            _tableDal.Update(entity);
        }

        public void TChangeTableStatusToTrue(int tableId)
        {
            _tableDal.ChangeTableStatusToTrue(tableId);
        }

        public void TChangeTableStatusToFalse(int tableId)
        {
            _tableDal.ChangeTableStatusToFalse(tableId);
        }
    }
}
