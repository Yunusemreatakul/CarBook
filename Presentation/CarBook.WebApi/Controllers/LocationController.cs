using CarBook.Application.Features.Mediator.Commands.LocationCommands;
using CarBook.Application.Features.Mediator.Queries.LocationQuery;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetLocation(int Id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Başarı ile eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme illemi başarılı şekilde gerçekleştirildi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(RemoveLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Silme İşlemi başarılı şekilde gerçekleştirildi");
        }
    }
}
