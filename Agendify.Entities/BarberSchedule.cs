using Agendify.Abstactions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class BarberSchedule : IEntidad
    {
        [Key]
        public int Id { get; set; }

        public DayOfWeek Day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        [ForeignKey(nameof(Barber))]
        public int BarberId { get; set; }
        public virtual Barber? Barber { get; set; }
    }
}
