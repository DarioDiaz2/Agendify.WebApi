using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.IdentityUser
{
    public class UserRegistroResponseDto
    {
        [Required]
        public string NombreCompleto { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
