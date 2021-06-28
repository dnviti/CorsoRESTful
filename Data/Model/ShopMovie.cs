namespace Data.Model
{
    [Table("ShopsMovies")]
    public record ShopMovie
    {
        [Required]
        public int ShopId { get; set; }
        [Required]
        public Shop Shop { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public Movie Movie { get; set; }
    }
}
