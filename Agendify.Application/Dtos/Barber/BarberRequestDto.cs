using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Barber
{
    public class BarberRequestDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [StringLength(100)]
        public string? Specialty { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }
    }
}
