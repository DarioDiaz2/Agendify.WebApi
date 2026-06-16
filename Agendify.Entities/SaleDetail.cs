using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class SaleDetail:IEntidad
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Sale))]
        public int SaleId { get; set; }

        public virtual Sale? Sale { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }
    }
}
