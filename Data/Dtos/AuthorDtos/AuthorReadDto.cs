﻿namespace Data.Dtos.AuthorDtos
{
    public class AuthorCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        public int Role { get; set; }
    }
}
