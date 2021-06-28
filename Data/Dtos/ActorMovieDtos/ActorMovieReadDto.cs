namespace Data.Dtos.ActorMovieDtos
{
    public record ActorMovieReadDto
    {
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
