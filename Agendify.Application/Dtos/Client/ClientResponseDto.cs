namespace Agendify.Application.Dtos.Client
{
    public class ClientResponseDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
