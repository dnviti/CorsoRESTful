using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.MovieDtos
{
    public class MovieCreateDto
    {
        [Required]
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
