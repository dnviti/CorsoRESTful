using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.ActorMovieDtos
{
    public record ActorMovieCreateDto
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
