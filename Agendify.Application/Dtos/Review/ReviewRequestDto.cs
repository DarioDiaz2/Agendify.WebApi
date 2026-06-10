using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Review
{
    public class ReviewRequestDto
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int BarberId { get; set; }
        

        [StringLength(500)]
        public string? Comment { get; set; }
    }
}
