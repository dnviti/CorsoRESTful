using AutoMapper;
using Data.Dtos.ActorMovieDtos;
using Data.Dtos.MovieDtos;
using Data.Model;
namespace Data.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            // Source -> Target
            CreateMap<Movie, MovieReadDto>().ReverseMap();
            CreateMap<Movie, MovieCreateDto>().ReverseMap();
            CreateMap<Movie, MovieUpdateDto>().ReverseMap();
        }

    }
}
