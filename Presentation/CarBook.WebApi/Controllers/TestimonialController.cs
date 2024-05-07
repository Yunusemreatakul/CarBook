using CarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using CarBook.Application.Features.Mediator.Queries.TestimonialQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediattor;

        public TestimonialController(IMediator mediattor)
        {
            _mediattor = mediattor;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediattor.Send(command);
            return Ok("Ürün Başarılı Şekilde Eklendi");
        }
        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _mediattor.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTestimonial(int Id)
        {
            var value = await _mediattor.Send(new GetTestiMonialByIdQuery(Id));
            return Ok(value);   
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonail(UpdateTestimonialCommand command)
        {
            await _mediattor.Send(command);
            return Ok("Başrılı şekilde güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(RemoveTestimonialCommand command)
        {
            await _mediattor.Send(command);
            return Ok("Başrılı Şekilde silindi");
        }
    }
}
