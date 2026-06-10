namespace Agendify.Application.Dtos.Review
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BarberId { get; set; }
        public string? Comment { get; set; }

        public DateTime ReviewDate { get; set; }
    }
}
