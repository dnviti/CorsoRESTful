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
