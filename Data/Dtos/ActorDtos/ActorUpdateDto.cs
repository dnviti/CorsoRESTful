namespace Data.Dtos.ActorDtos
{
    public record ActorUpdateDto
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
