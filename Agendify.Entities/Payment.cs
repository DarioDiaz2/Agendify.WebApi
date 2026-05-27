

using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class Payment : IEntidad
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public virtual Appointment? Appointment { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }

    }
}
