namespace Agendify.Entities
{
    public class ServiceClient
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public decimal Price { get; set; }
        public int DurationMinutes { get; set; }
    }
}
