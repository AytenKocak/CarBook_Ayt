using CarBook.Application.Features.Mediator.Commands.CreateFeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using CarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAdressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAdressesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAdressList()
        {
            var values = await _mediator.Send(new GetFooterAdressQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAdress(int id)
        {
            var value = await _mediator.Send(new GetFooterAdressByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFooterAdressCommand command)
        {

            await _mediator.Send(command);
            return Ok("FooterAdress başarı ile  eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAdress(int id)
        {
            await _mediator.Send(new RemoveFooterAdressCommand(id));
            return Ok("FooterAdress başarı ile silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAdress(UpdateFooterAdressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik başarı ile güncellendi");
        }
    }
}
