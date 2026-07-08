using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Login
{
    public class LoginUserRequestDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
