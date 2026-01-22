using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBookApi.Controllers
{
  

namespace CarBookApi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ContactsController : ControllerBase
        {
            private readonly CreateContactCommandHandler _createContactCommandHandler;
            private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
            private readonly GetContactQueryHandler _getContactQueryHandler;
            private readonly RemoveContactCommandHandler _removeContactCommandHandler;
            private readonly UpdateContactCommandHandler _updateContactCommandHandle;

            public ContactsController(CreateContactCommandHandler createContactCommandHandler,
                GetContactByIdQueryHandler getContactByIdQueryHandler,
                GetContactQueryHandler getContactQueryHandler,
                RemoveContactCommandHandler removeContactCommandHandler,
                UpdateContactCommandHandler updateContactCommandHandle)
            {
                _createContactCommandHandler = createContactCommandHandler;
                _getContactByIdQueryHandler = getContactByIdQueryHandler;
                _getContactQueryHandler = getContactQueryHandler;
                _removeContactCommandHandler = removeContactCommandHandler;
                _updateContactCommandHandle = updateContactCommandHandle;
            }
            [HttpGet]
            public async Task<IActionResult> ContactList()
            {
                var result = await _getContactQueryHandler.Handle();
                return Ok(result);
            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetContact(int id)
            {
                var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQueries(id));
                return Ok(value);

            }
            [HttpPost]
            public async Task<IActionResult> CreateContact(CreateContactCommand command)
            {
                await _createContactCommandHandler.Handle(command);
                return Ok("İletişim Bilgisi Eklendi");


            }
            [HttpDelete("{id}")]
            public async Task<IActionResult> RemoveContact(int id)
            {
                await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
                return Ok("İletişim Bilgisi Silindi");
            }
            [HttpPut]
            public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
            {
                await _updateContactCommandHandle.Handle(command);
                return Ok("İletişim Bilgisi Güncellendi");
            }
        }
    }

}

