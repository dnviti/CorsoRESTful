using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    [Table("ActorsMovies")]
    public class ActorMovie
    {
        [Required]
        public long ActorId { get; set; }
        [Required]
        public Actor Actor { get; set; }
        [Required]
        public long MovieId { get; set; }
        [Required]
        public Movie Movie { get; set; }
    }
}
