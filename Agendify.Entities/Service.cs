using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace Agendify.Entities
{
    public class Service:IEntidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int DurationMinutes { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();
    }
}
