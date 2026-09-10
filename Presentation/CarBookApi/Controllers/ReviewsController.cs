using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetReviewsListByCarId(int id)
        {  var values = await _mediator.Send(new  GetReviewByCarIdQuery( id));
            return Ok(values);
        
        }
        [HttpPost]
        public async Task<IActionResult> AddReview(CreateReviewCommand command)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }   

            await _mediator.Send(command);
            return Ok();
        }
                 
    }
}
