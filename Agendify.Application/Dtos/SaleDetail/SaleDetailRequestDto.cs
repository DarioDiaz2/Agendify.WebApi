using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.SaleDetail
{
    public class SaleDetailRequestDto
    {
        [Required]
        public int SaleId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
