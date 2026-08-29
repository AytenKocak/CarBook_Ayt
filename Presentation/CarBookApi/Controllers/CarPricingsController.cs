using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarPricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarPricingWithCarList()
        {
            var result = await _mediator.Send(new GetCarPricingWithCarQuery());
            return Ok(result);
        }
        [HttpGet("GetCarPricingWithTimePeriod")]
        public async Task<IActionResult> GetCarPricingWithTimePeriod()
        {
            var result = await _mediator.Send(new GetCarPricingWithTimePeriodQuery());
            return Ok(result);
        }
    }
}
