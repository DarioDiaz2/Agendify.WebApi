namespace Agendify.Application.Dtos.Sale
{
    public class SaleResponseDto
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public DateTime SaleDate { get; set; }

        public decimal Total { get; set; }
    }
}
