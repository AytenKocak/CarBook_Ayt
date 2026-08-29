using CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescribtionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarDescribtionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarDescriptionsById(int id)
        {
            var values = await _mediator.Send(new GetCarDEscribtionByCarIdQuery(id));
            return Ok(values);

        }

    }
}
