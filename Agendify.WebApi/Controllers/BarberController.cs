using Agendify.Application;
using Agendify.Application.Dtos.Barber;
using Agendify.Application.Dtos.Service;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberController : ControllerBase
    {

        private readonly ILogger<BarberController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Barber> _barber;
        private readonly IMapper _mapper;
        public BarberController(IApplication<Barber> barber, ILogger<BarberController> logger, IStringService stringService, IMapper mapper)
        {
            _barber = barber;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<BarberResponseDto>>(_barber.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Barber barber = _barber.GetById(Id.Value);
            if (barber is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BarberResponseDto>(barber));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(BarberRequestDto barberRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var barber = _mapper.Map<Barber>(barberRequestDto);
            _barber.Save(barber);
            return Ok(barber.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, BarberRequestDto barberRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Barber barberBack = _barber.GetById(Id.Value);
            if (barberBack is null)
            { return NotFound(); }
            _mapper.Map(barberRequestDto, barberBack);
            _barber.Save(barberBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            Barber barberBack = _barber.GetById(Id.Value);
            if (barberBack is null)
            { return NotFound(); }
            _barber.Delete(barberBack.Id);
            return Ok();
        }
    }
}
