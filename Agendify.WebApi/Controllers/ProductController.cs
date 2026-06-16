using Agendify.Application;
using Agendify.Application.Dtos.Product;
using Agendify.Application.Dtos.Review;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Product> _product;
        private readonly IMapper _mapper;

        public ProductController(IApplication<Product> product, ILogger<ProductController> logger, IStringService stringService, IMapper mapper)
        {
            _product = product;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ProductResponseDto>>(_product.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Product product = _product.GetById(Id.Value);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductResponseDto>(product));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ProductRequestDto productRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var product = _mapper.Map<Product>(productRequestDto);

            product.Active = true;

            _product.Save(product);

            return Ok(product.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ProductRequestDto productRequestDto)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Product productBack = _product.GetById(Id.Value);

            if (productBack  is null)
            {
                return NotFound();
            }

            _mapper.Map(productRequestDto, productBack);

            _product.Save(productBack);

            return Ok(productBack);
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

