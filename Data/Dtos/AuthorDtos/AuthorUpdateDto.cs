namespace Data.Dtos.AuthorDtos
{
    public record AuthorUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public int Role { get; set; }
    }
}
