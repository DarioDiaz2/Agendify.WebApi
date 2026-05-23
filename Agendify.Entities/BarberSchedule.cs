using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agendify.Entities
{
    public class BarberSchedule
    {
        [Key]
        public int BarberScheduleId { get; set; }

        public DayOfWeek Day { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int BarberId { get; set; }

        [ForeignKey("BarberId")]
        public virtual Barber? Barber { get; set; }
    }
}
