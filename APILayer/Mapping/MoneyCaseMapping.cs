using AutoMapper;
using DTOLayer.MoneyCaseDto;
using EntityLayer.Entities;

namespace APILayer.Mapping
{
    public class MoneyCaseMapping : Profile
    {
        public MoneyCaseMapping()
        {
            CreateMap<MoneyCase, ResultMoneyCaseDto>().ReverseMap();
        }
    }
}
