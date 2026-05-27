using Agendify.Application;
using Agendify.Application.Dtos.Service;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {

        private readonly ILogger<ServiceController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Service> _autor;
        private readonly IMapper _mapper;
        public ServiceController(IApplication<Service> autor
            , ILogger<ServiceController> logger
            , IStringService stringService
            , IMapper mapper)
        {
            _autor = autor;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ServiceResponseDto>>(_autor.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Service autor = _autor.GetById(Id.Value);
            if (autor is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ServiceResponseDto>(autor));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ServiceRequestDto serviceRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var service = _mapper.Map<Service>(serviceRequestDto);
            _autor.Save(service);
            return Ok(service.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ServiceRequestDto serviceRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Service serviceBack = _autor.GetById(Id.Value);
            if (serviceBack is null)
            { return NotFound(); }
            _mapper.Map(serviceRequestDto, serviceBack);
            _autor.Save(serviceBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            Service serviceBack = _autor.GetById(Id.Value);
            if (serviceBack is null)
            { return NotFound(); }
            _autor.Delete(serviceBack.Id);
            return Ok();
        }
    }
}
