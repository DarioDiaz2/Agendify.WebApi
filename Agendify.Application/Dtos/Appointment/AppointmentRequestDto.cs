using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Appointment
{
    public class AppointmentRequestDto
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int BarberId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public decimal Total { get; set; }
    }
}
