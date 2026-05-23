using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client? Client { get; set; }

        public int BarberId { get; set; }

        [ForeignKey("BarberId")]
        public virtual Barber? Barber { get; set; }

        public DateTime Date { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
