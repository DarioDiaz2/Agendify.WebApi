namespace Agendify.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Gmail { get; set; } = null!;
        public int DNI { get; set; }
    }
}
