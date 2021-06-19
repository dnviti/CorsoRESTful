using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.MovieDtos
{
    public class MovieCreateDto
    {
        [Required]
        public string Name { get; set; }
        public double Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
