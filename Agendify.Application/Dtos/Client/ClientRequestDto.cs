using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Client
{
    public class ClientRequestDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }
    }
}
