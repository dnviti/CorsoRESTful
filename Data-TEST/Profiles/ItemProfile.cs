using AutoMapper;
using Data_TEST.Model;

namespace Data_TEST.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemCreateDto>().ReverseMap();
            CreateMap<Item, ItemReadDto>().ReverseMap();
            CreateMap<Item, ItemUpdateDto>().ReverseMap();
        }
    }
}