using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.IdentityUser
{
    public class UserRegistroRequestDto
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
