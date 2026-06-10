using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace Agendify.Entities
{
    public class Barber : IEntidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [StringLength(100)]
        public string? Specialty { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
