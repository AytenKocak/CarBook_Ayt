using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Features.Mediator.Queries;
using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);  
        }
        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }
        [HttpGet("GetAuthourCount")]
        public async Task<IActionResult> GetAuthourCount()
        {
            var values = await _mediator.Send(new GetAuthourCountQuery());
            return Ok(values);
        }
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }
        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }
        [HttpGet("GetAvrgRentPriceForDaily")]
        public async Task<IActionResult> GetAvrgRentPriceForDaily()
        {
            var values = await _mediator.Send(new GetAvrgRentPriceForDailyQuery());
            return Ok(values);
        }
        [HttpGet("GetAvrgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvrgRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAvrgRentPriceForWeeklyQuery());
            return Ok(values);
        }
        [HttpGet("GetAvrgRentPriceForMountly")]
        public async Task<IActionResult> GetAvrgRentPriceForMountly()
        {
            var values = await _mediator.Send(new GetAvrgRentPriceForMountlyQuery());
            return Ok(values);
        }
      
     
        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public async Task<IActionResult> GetCarCountByTransmissionIsAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(values);
        }
        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }
        
       [HttpGet("GetBlogTitleByMaxComment")]
        public async Task<IActionResult> GetBlogTitleByMaxComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxCommentQuery());
            return Ok(values);
        }
        
        [HttpGet("GetCarCountSmallerThan1000")]
        public async Task<IActionResult> GetCarCountSmallerThan1000()
        {
            var values = await _mediator.Send(new GetCarCountSmallerThan1000Query());
            return Ok(values);
        }
      
        [HttpGet("GetCarCountByGasolineOrDisel")]
        public async Task<IActionResult> GetCarCountByGasolineOrDisel()
        {
            var values = await _mediator.Send(new GetCarCountByGasolineOrDiselQuery());
            return Ok(values);
        }
        
        [HttpGet("GetCarCountByElectiric")]
        public async Task<IActionResult> GetCarCountByElectiric()
        {
            var values = await _mediator.Send(new GetCarCountByElectiricQuery());
            return Ok(values);
        }
        
        [HttpGet("GetCarBrandAndModelRentPriceMountlyMax")]
        public async Task<IActionResult> GetCarBrandAndModelRentPriceMountlyMax()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelRentPriceMountlyMaxQuery());
            return Ok(values);
        }

        
        [HttpGet("GetCarBrandAndModelRentPriceWeeklyMin")]
        public async Task<IActionResult> GetCarBrandAndModelRentPriceWeeklyMin()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelRentPriceWeeklyMinQuery());
            return Ok(values);
        }
        
        [HttpGet("GetCarBrandAndModelRentPriceDaily")]
        public async Task<IActionResult> GetCarBrandAndModelRentPriceDaily()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelRentPriceDailyQuery());
            return Ok(values);
        }
       
        [HttpGet("GetBlogCountQueryX")]
        public async Task<IActionResult> GetBlogCountQueryX()
        {
            var values = await _mediator.Send(new GetBlogCountQueryXQuery());
            return Ok(values);
        }

    }
}
