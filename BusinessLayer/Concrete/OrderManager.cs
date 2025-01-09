using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(Context context, IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public int TActiveOrderCount()
        {
            return _orderDal.ActiveOrderCount();
        }

        public bool TCompleteOrderByTableId(int tableId)
        {
            return _orderDal.CompleteOrderByTableId(tableId);
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public List<Order> TGetListWhere(Expression<Func<Order, bool>> predicate)
        {
            return _orderDal.GetListWhere(predicate);
        }

        public void TInsert(Order entity)
        {
            _orderDal.Insert(entity);
        }

        public decimal TLastOrderPrice()
        {
            return _orderDal.LastOrderPrice();
        }

        public decimal TTodayTotalPrice()
        {
            return _orderDal.TodayTotalPrice();
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount();
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
