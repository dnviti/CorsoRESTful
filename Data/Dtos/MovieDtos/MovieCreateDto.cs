using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.MovieDtos
{
    public class MovieCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string VatCode { get; set; }
        public string Description { get; set; }
    }
}
