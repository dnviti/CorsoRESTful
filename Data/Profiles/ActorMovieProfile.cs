using AutoMapper;
using Data.Dtos.ActorMovieDtos;
using Data.Model;

namespace Data.Profiles
{
    public class ActorMovieProfile : Profile
    {
        public ActorMovieProfile()
        {
            // Source -> Target
            CreateMap<ActorMovie, ActorMovieReadDto>().ReverseMap();
            CreateMap<ActorMovie, ActorMovieCreateDto>().ReverseMap();
        }
    }
}