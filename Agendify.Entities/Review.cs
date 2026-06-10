using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class Review : IEntidad
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
        [ForeignKey(nameof(Barber))]
        public int BarberId { get; set; }

        public virtual Barber? Barber { get; set; }
        [StringLength(500)]
        public string? Comment { get; set; }

        public DateTime ReviewDate { get; set; }

    }
}
