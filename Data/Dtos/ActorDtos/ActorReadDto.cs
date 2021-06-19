using System;

namespace Data.Dtos.ActorDtos
{
    public class ActorReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Role { get; set; }
    }
}
