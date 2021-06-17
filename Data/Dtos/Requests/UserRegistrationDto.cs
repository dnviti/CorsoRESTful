using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.Requests
{
    public class UserRegistrationDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}
