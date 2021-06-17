using System.ComponentModel.DataAnnotations;

namespace Data.Dtos.Requests
{
    public class UserLoginRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
