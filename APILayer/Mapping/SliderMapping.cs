using AutoMapper;
using DTOLayer.SliderDto;
using EntityLayer.Entities;

namespace APILayer.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
        }
    }
}
