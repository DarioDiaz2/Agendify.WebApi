using Agendify.Application;
using Agendify.Application.Dtos.Product;
using Agendify.Application.Dtos.SaleDetail;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly ILogger<SaleDetailController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<SaleDetail> _saleDetail;
        private readonly IApplication<Product> _product;
        private readonly IMapper _mapper;

        public SaleDetailController(IApplication<SaleDetail> saleDetail, ILogger<SaleDetailController> logger, IStringService stringService, IApplication<Product> product, IMapper mapper)
        {
            _saleDetail = saleDetail;
            _logger = logger;
            _stringService = stringService;
            _product = product;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<SaleDetailResponseDto>>(_saleDetail.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            SaleDetail saleDetail = _saleDetail.GetById(Id.Value);

            if (saleDetail is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SaleDetailResponseDto>(saleDetail));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(SaleDetailRequestDto saleDetailRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Product product = _product.GetById(saleDetailRequestDto.ProductId);

            if (product is null)
            {
                return NotFound("Producto no encontrado");
            }

            var saleDetail = _mapper.Map<SaleDetail>(saleDetailRequestDto);

            saleDetail.UnitPrice = product.Price;
            saleDetail.SubTotal = saleDetail.Quantity * product.Price;

            _saleDetail.Save(saleDetail);

            return Ok(saleDetail.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, SaleDetailRequestDto saleDetailRequestDto)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            SaleDetail saleDetailBack = _saleDetail.GetById(Id.Value);

            if (saleDetailBack is null)
            {
                return NotFound();
            }

            Product product = _product.GetById(saleDetailRequestDto.ProductId);

            if (product is null)
            {
                return NotFound("Producto no encontrado");
            }

            _mapper.Map(saleDetailRequestDto, saleDetailBack);

            saleDetailBack.UnitPrice = product.Price;
            saleDetailBack.SubTotal = saleDetailBack.Quantity * product.Price;

            _saleDetail.Save(saleDetailBack);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Product productBack = _product.GetById(Id.Value);

            if (productBack is null)
            {
                return NotFound();
            }

            _product.Delete(productBack.Id);

            return Ok();
        }

    }
}
