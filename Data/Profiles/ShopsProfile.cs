using AutoMapper;
using Data.Dtos.ActorMovieDtos;
using Data.Dtos.ShopDtos;
using Data.Model;
namespace Data.Profiles
{
    public class ShopsProfile : Profile
    {
        public ShopsProfile()
        {
            // Source -> Target
            CreateMap<Shop, ShopReadDto>().ReverseMap();
            CreateMap<Shop, ShopUpdateDto>().ReverseMap();
            CreateMap<Shop, ShopCreateDto>().ReverseMap();
        }

    }
}
