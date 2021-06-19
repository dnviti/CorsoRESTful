using AutoMapper;
using Data.Dtos.ActorDtos;
using Data.Model;

namespace Data.Profiles
{
    public class ActorsProfile : Profile
    {
        public ActorsProfile()
        {
            // Source -> Target
            CreateMap<Actor, ActorReadDto>().ReverseMap();
            CreateMap<Actor, ActorCreateDto>().ReverseMap();
            CreateMap<Actor, ActorUpdateDto>().ReverseMap();
        }

    }
}
