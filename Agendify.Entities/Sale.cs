using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class Sale : IEntidad
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public virtual Client? Client { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }= new List<SaleDetail>();
    }
}
