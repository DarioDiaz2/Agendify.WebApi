using Agendify.Abstactions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendify.Entities
{
    public class AppointmentService : IEntidad
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public virtual Appointment? Appointment { get; set; }

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }

        public virtual Service? Service { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
