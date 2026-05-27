using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class Appointment : IEntidad
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        public virtual Client? Client { get; set; }

        [ForeignKey(nameof(Barber))]
        public int BarberId { get; set; }

        public virtual Barber? Barber { get; set; }

        public DateTime Date { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }

        public decimal Total { get; set; }

        public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
