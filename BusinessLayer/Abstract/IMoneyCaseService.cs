using EntityLayer.Entities;

namespace BusinessLayer.Abstract
{
    public interface IMoneyCaseService : IGenericService<MoneyCase>
    {
        decimal TGetMoneyCaseAmount();
    }
}
