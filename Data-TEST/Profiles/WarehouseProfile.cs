using AutoMapper;
using Data_TEST.Model;

namespace Data_TEST.Profiles
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseCreateDto>().ReverseMap();
            CreateMap<Warehouse, WarehouseReadDto>().ReverseMap();
            CreateMap<Warehouse, WarehouseUpdateDto>().ReverseMap();
        }
    }
}