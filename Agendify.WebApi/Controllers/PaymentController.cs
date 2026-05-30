using Agendify.Application;
using Agendify.Application.Dtos.Payment;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Payment> _payment;
        private readonly IMapper _mapper;

        public PaymentController(
            IApplication<Payment> payment,
            ILogger<PaymentController> logger,
            IStringService stringService,
            IMapper mapper)
        {
            _payment = payment;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<PaymentResponseDto>>(_payment.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Payment payment = _payment.GetById(Id.Value);

            if (payment is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PaymentResponseDto>(payment));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(PaymentRequestDto paymentRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var payment = _mapper.Map<Payment>(paymentRequestDto);

            payment.PaymentDate = DateTime.Now;

            _payment.Save(payment);

            return Ok(payment.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, PaymentRequestDto paymentRequestDto)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Payment paymentBack = _payment.GetById(Id.Value);

            if (paymentBack is null)
            {
                return NotFound();
            }

            _mapper.Map(paymentRequestDto, paymentBack);

            _payment.Save(paymentBack);

            return Ok(paymentBack);
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Payment paymentBack = _payment.GetById(Id.Value);

            if (paymentBack is null)
            {
                return NotFound();
            }

            _payment.Delete(paymentBack.Id);

            return Ok();
        }
    }
}
