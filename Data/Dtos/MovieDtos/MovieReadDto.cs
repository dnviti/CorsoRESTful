using System;

namespace Data.Dtos.MovieDtos
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
