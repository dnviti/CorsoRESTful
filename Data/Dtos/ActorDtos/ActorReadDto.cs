using System;

namespace Data.Dtos.ActorDtos
{
    public class ActorCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Role { get; set; }
    }
}
