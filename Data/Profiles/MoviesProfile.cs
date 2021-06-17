using AutoMapper;
using Data.Dtos.MovieDtos;
using Data.Model;

namespace Data.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile()
        {
            // Source -> Target
            CreateMap<Movie, MovieReadDto>();
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();
            CreateMap<Movie, MovieUpdateDto>();
        }

    }
}
