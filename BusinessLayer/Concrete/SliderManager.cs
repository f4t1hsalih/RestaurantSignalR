using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void TDelete(Slider entity)
        {
            throw new NotImplementedException();
        }

        public Slider TGetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public List<Slider> TGetListAll()
        {
            return _sliderDal.GetListAll();
        }

        public List<Slider> TGetListWhere(Expression<Func<Slider, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void TInsert(Slider entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}
