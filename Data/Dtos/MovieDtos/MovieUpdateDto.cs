using System;

namespace Data.Dtos.MovieDtos
{
    public record MovieUpdateDto
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
