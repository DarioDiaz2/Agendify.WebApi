namespace Agendify.Application.Dtos.Payment
{
    public class PaymentResponseDto
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
