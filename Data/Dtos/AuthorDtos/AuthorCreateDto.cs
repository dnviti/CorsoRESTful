﻿using Data.Model;
using System;
using System.Collections.Generic;

namespace Data.Dtos.AuthorDtos
{
    public class AuthorReadDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Role { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}
