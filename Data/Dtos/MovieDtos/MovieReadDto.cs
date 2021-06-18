using System;

namespace Data.Dtos.MovieDtos
{
    public class MovieReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
