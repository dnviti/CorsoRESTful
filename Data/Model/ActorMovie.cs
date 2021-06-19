﻿namespace Data.Model
{
    [Table("ActorsMovies")]
    public class ActorMovie
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
