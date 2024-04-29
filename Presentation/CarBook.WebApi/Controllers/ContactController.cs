using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly GetContactByIdCommandHandler _getContactByIdCommandHandler;
        private readonly GetContactCommandHandler _getContactCommandHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;

        public ContactController(GetContactByIdCommandHandler getContactByIdCommandHandler, GetContactCommandHandler getContactCommandHandler, CreateContactCommandHandler createContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler)
        {
            _getContactByIdCommandHandler = getContactByIdCommandHandler;
            _getContactCommandHandler = getContactCommandHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactCommandHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetContact(int Id)
        {
            var value = await _getContactByIdCommandHandler.Handle(new GetContactByIdQuery(Id));
            return Ok(value);

        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı şekilde yapıldı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int Id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(Id));
            return Ok("Silme İşlemi Başarılı Şekiled yapıldı");
        }
    }
}
