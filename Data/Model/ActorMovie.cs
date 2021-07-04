using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("ActorsMovies")]
    public record ActorMovie
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        public Actor Actor { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public Movie Movie { get; set; }
    }
}
