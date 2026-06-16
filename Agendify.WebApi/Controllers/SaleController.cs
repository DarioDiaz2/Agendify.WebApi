using Agendify.Application;
using Agendify.Application.Dtos.Sale;
using Agendify.Application.Dtos.Service;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Sale> _sale;
        private readonly IMapper _mapper;
        public SaleController(IApplication<Sale> sale, ILogger<SaleController> logger, IStringService stringService, IMapper mapper)
        {
            _sale = sale;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<SaleResponseDto>>(_sale.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }
            Sale autor = _sale.GetById(Id.Value);
            if (autor is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SaleResponseDto>(autor));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SaleRequestDto saleRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var sale = _mapper.Map<Sale>(saleRequestDto);

            
            sale.SaleDate = DateTime.Now;

            
            sale.Total = 0;

            _sale.Save(sale);

            return Ok(sale.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, SaleRequestDto saleRequestDto)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            if (!ModelState.IsValid)
            { return BadRequest(); }
            Sale saleBack = _sale.GetById(Id.Value);
            if (saleBack is null)
            { return NotFound(); }
            _mapper.Map(saleRequestDto, saleBack);
            _sale.Save(saleBack);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            { return BadRequest(); }
            Sale saleBack = _sale.GetById(Id.Value);
            if (saleBack is null)
            { return NotFound(); }
            _sale.Delete(saleBack.Id);
            return Ok();
        }
    }
}
