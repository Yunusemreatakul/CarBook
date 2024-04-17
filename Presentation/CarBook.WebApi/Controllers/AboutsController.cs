using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createCommandHandler;
        private readonly GetAboutQueryByIdHandler _getAboutQueryByIdHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;
        private readonly RemoveAboutCommandHandler _removeCommandHandler;
        private readonly UpdateAboutCommandHandler _updateCommandHandler;

        public AboutsController(CreateAboutCommandHandler createCommandHandler, GetAboutQueryByIdHandler getAboutQueryByIdHandler, GetAboutQueryHandler getAboutQueryHandler, RemoveAboutCommandHandler removeCommandHandler, UpdateAboutCommandHandler updateCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _getAboutQueryByIdHandler = getAboutQueryByIdHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
            _removeCommandHandler = removeCommandHandler;
            _updateCommandHandler = updateCommandHandler;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("Hakkımda bilgisi Başarı İle Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbout(int id)
        {
            var values =await _getAboutQueryByIdHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values =await _getAboutQueryHandler.Handler();
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int Id)
        {
            await _removeCommandHandler.Handler(new RemoveAboutCommand(Id));
            return Ok("Kayıt Başarılı şekilde silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateCommandHandler.Handle(command);
            return Ok("Kayıt Başrılı Şekilde Güncellendi");
        }

    }
}
