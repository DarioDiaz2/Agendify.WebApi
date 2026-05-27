namespace Agendify.Application.Dtos.Barber
{
    public class BarberResponseDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string? Specialty { get; set; }

        public string? Phone { get; set; }

        public bool Active { get; set; }
    }
}
