using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Product
{
    public class ProductRequestDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Stock { get; set; }
    }
}
