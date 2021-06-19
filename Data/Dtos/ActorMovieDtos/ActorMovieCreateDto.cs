namespace Data.Dtos.ActorMovieDtos
{
    public class ActorMovieCreateDto
    {
        [Required]
        public int ActorId { get; set; }
        [Required]
        public int MovieId { get; set; }
    }
}
