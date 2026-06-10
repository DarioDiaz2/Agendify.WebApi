using Agendify.Application;
using Agendify.Application.Dtos.Payment;
using Agendify.Application.Dtos.Review;
using Agendify.Entities;
using Agendify.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agendify.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IStringService _stringService;
        private readonly IApplication<Review> _review;
        private readonly IMapper _mapper;

        public ReviewController(IApplication<Review> review,ILogger<ReviewController> logger,IStringService stringService,IMapper mapper)
        {
            _review = review;
            _logger = logger;
            _stringService = stringService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All()
        {
            return Ok(_mapper.Map<IList<ReviewResponseDto>>(_review.GetAll()));
        }

        [HttpGet]
        [Route("ById")]
        public async Task<IActionResult> ById(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Review review = _review.GetById(Id.Value);

            if (review is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ReviewResponseDto>(review));
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ReviewRequestDto reviewRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var review = _mapper.Map<Review>(reviewRequestDto);

            review.ReviewDate = DateTime.Now;

            _review.Save(review);

            return Ok(review.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(int? Id, ReviewRequestDto reviewRequestDto)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Review reviewBack = _review.GetById(Id.Value);

            if (reviewBack is null)
            {
                return NotFound();
            }

            _mapper.Map(reviewRequestDto, reviewBack);

            _review.Save(reviewBack);

            return Ok(reviewBack);
        }

        [HttpDelete]
        public async Task<IActionResult> Borrar(int? Id)
        {
            if (!Id.HasValue)
            {
                return BadRequest();
            }

            Review reviewBack = _review.GetById(Id.Value);

            if (reviewBack is null)
            {
                return NotFound();
            }

            _review.Delete(reviewBack.Id);

            return Ok();
        }

    }
}
