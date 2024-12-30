using AutoMapper;
using DTOLayer.TableDto;
using EntityLayer.Entities;

namespace APILayer.Mapping
{
    public class TableMapping : Profile
    {
        public TableMapping()
        {
            CreateMap<Table, ResultTableDto>().ReverseMap();
            CreateMap<Table, InsertTableDto>().ReverseMap();
            CreateMap<Table, UpdateTableDto>().ReverseMap();
            CreateMap<Table, GetTableDto>().ReverseMap();
        }
    }
}
