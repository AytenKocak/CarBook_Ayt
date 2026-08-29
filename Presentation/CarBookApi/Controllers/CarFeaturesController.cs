using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            var values = await _mediator.Send(
                new GetCarFeatureByCarIdQuery(id)
            );

            return Ok(values);
        }
        [HttpGet("CarFeatureChangeAvaliableToFalse")]
        public async Task <IActionResult> CarFeatureChangeAvaliableToFalse(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaliableCahangeToFalseCommand(id));
            return Ok("Güncelleme yapıldı");   
        }
        [HttpGet("CarFeatureChangeAvaliableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvaliableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvaliableCahangeToTrueCommand(id));
            return Ok("Güncelleme yapıldı");
        }
        [HttpPost]
        public async Task <IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarCommand command)
        {
            var values = await _mediator.Send(command);
            return Ok("Güncelleme yapıldı");
        }
    }
}