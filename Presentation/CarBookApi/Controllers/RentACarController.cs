using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetRentACarByLocation(int locationID,bool avaliable)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery();
            {
                getRentACarQuery.LocationID = locationID;
                getRentACarQuery.Avaliable = avaliable;


            }

            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
    }
}
