using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Features.Mediator.Handlers.SocialMediaHandler;
using CarBook.Application.Features.Mediator.Queries.ServiceQuery;
using CarBook.Application.Features.Mediator.Queries.SocialMediaQuery;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GerSocialMedia(int Id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Değer başarılı şekilde eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme işlemi başarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(RemoveSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Değer silindi");
        }
    }
}
