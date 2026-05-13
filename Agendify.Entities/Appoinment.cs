namespace Agendify.Entities
{
    public class Appoinment
    {
        public int AppointmentId { get; set; }

        public DateTime Date { get; set; }

        public int ClientId { get; set; }

        public int BarberId { get; set; }

        public int ServiceId { get; set; }
        

        
    }
}
