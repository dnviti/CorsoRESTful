using AutoMapper;
using Data.Dtos.ShopDtos;
using Data.Model;

namespace Data.Profiles
{
    public class ShopsProfile : Profile
    {
        public ShopsProfile()
        {
            // Source -> Target
            CreateMap<Shop, ShopReadDto>();
            CreateMap<ShopCreateDto, Shop>();
            CreateMap<ShopUpdateDto, Shop>();
            CreateMap<Shop, ShopUpdateDto>();
        }

    }
}
