using Agendify.Application;
using Agendify.Entities;
using Agendify.Services;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<Service> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Service> _service;

        public ServicesController(
            IApplication<Service> service,
            ILogger<Service> logger,
            IStringService stringService)
        {
            _service = service;
            _logger = logger;
            _stringService = stringService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Service service = _service.GetById(Id.Value);

            if (service is null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _service.Save(service);

            return Ok(service.ServiceId);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, Service service)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Service serviceBack = _service.GetById(Id.Value);

            if (serviceBack is null)
            {
                return NotFound();
            }

            serviceBack.Name = service.Name;
            serviceBack.Price = service.Price;
            serviceBack.DurationMinutes = service.DurationMinutes;
            serviceBack.Active = service.Active;

            _service.Save(serviceBack);

            return Ok(serviceBack);
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Service serviceBack = _service.GetById(Id.Value);

            if (serviceBack is null)
            {
                return NotFound();
            }

            _service.Delete(serviceBack.ServiceId);

            return Ok();
        }
    }
}