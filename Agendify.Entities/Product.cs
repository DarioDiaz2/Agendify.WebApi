using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace Agendify.Entities
{
    public class Product:IEntidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }= new List<SaleDetail>();
    }
}
