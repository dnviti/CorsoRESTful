namespace Data.Dtos.MovieDtos
{
    public record MovieReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public IEnumerable<object> Links { get; set; }
    }
}
