namespace Data.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            // Source -> Target
            CreateMap<Author, AuthorReadDto>().ReverseMap();
            CreateMap<Author, AuthorCreateDto>().ReverseMap();
            CreateMap<Author, AuthorUpdateDto>().ReverseMap();
        }

    }
}
