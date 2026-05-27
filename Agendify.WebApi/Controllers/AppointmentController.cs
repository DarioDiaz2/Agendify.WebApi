using Agendify.Application;
using Agendify.Application.Dtos.Appointment;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Appointment> _appointment;
        private readonly IMapper _mapper;
        public AppointmentController(IApplication<Appointment> appointment
            , ILogger<AppointmentController> logger
            , IStringService stringService
            , IMapper mapper)
        {
            _appointment = appointment;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<AppointmentResponseDto>>(_appointment.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Appointment appointment = _appointment.GetById(Id.Value);
            if (appointment is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<AppointmentResponseDto>(appointment));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(AppointmentRequestDto appointmentRequestDto)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            var appointment = _mapper.Map<Appointment>(appointmentRequestDto);
            _appointment.Save(appointment);
            return Ok(appointment.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, AppointmentRequestDto appointmentRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Appointment appointmentBack = _appointment.GetById(Id.Value);
            if (appointmentBack is null)
            { return NotFound(); }
            _mapper.Map(appointmentRequestDto, appointmentBack);
            _appointment.Save(appointmentBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            Appointment appointmentBack = _appointment.GetById(Id.Value);
            if (appointmentBack is null)
            { return NotFound(); }
            _appointment.Delete(appointmentBack.Id);
            return Ok();
        }
    }
    
}
