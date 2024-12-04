using EntityLayer.Entities;

namespace DataAccessLayer.Abstract
{
    public interface IMoneyCaseDal : IGenericDal<MoneyCase>
    {
        decimal GetMoneyCaseAmount();
    }
}
