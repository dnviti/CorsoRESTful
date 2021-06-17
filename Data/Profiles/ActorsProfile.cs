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
            CreateMap<Actor, ActorReadDto>();
            CreateMap<ActorCreateDto, Actor>();
            CreateMap<ActorUpdateDto, Actor>();
            CreateMap<Actor, ActorUpdateDto>();
        }

    }
}
