namespace Data.Model
{
    [Table("Authors")]
    public class Author
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public int Role { get; set; }
        public IList<Movie> Movies { get; set; }
    }
}
