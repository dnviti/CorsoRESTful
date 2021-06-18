﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.ActorDtos
{
    public class ActorUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public int Role { get; set; }
        public ICollection<Movie> Movies { get; set; }
    }
}