using AutoMapper;
using DTOLayer.BasketDto;
using EntityLayer.Entities;

namespace APILayer.Mapping
{
    public class BasketMapping : Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketWithProductNamesDto>().ReverseMap();
        }
    }
}
