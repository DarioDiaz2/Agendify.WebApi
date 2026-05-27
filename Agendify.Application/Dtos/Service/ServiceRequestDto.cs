using System.ComponentModel.DataAnnotations;

namespace Agendify.Application.Dtos.Service
{
    public class ServiceRequestDto
    {
       
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
    }
}
