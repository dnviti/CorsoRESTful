using System;

namespace Data.Dtos.AuthorDtos
{
    public record AuthorCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Role { get; set; }
    }
}
