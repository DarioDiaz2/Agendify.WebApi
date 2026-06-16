using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Sale
{
    public class SaleRequestDto
    {
        [Required]
        public int ClientId { get; set; }
    }
}
