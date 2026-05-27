using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;

namespace Agendify.Entities
{
    public class Client : IEntidad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
