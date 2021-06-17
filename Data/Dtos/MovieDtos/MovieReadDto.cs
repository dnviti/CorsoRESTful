using System;

namespace Data.Dtos.MovieDtos
{
    public class MovieReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string VatCode { get; set; }
        public string Description { get; set; }
    }
}
