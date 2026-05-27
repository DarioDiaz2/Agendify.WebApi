namespace Agendify.Application.Dtos.Appointment
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string? ClientName { get; set; }

        public int BarberId { get; set; }

        public string? BarberName { get; set; }

        public DateTime Date { get; set; }

        public string? Notes { get; set; }

        public decimal Total { get; set; }
    }
}
