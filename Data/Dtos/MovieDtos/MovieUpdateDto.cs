using System;

namespace Data.Dtos.MovieDtos
{
    public class MovieUpdateDto
    {
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
