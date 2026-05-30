using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Payment
{
    public class PaymentRequestDto
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
