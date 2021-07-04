
using AutoMapper;
using Data.Dtos.ActorMovieDtos;
using Data.Dtos.AuthorDtos;
using Data.Model;
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
