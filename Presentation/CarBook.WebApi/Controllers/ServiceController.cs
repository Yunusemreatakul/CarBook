using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.ServiceQuery;
using CarBook.Application.Features.Mediator.Results.ServiceResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetService(int Id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(Id));
            return Ok(value);   
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Günccelndi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveService(RemoveServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Silme işlemi yapıldı");
        }
    }
}
