using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQuery;
using CarBook.Application.Features.Mediator.Results.PricingResult;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPricing(int Id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat bilgisi başarı ile eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme işlemi başarı ile gerçekleştirildi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePricing(RemovePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Silme işlemi başarılı şekile gerçekleştirildi");
        }
    }
}
