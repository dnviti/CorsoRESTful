using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.AuthorDtos
{
    public class AuthorReadDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required]
        public int Role { get; set; }
    }
}
