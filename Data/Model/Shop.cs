namespace Data.Model
{
    [Table("Shops")]
    public class Shop
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}
