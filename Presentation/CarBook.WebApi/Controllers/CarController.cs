using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCommandHandler;
        private readonly UpdateCarCommandHandler _updateCommandHandler;
        private readonly RemoveCarCommandHandler _removeCommandHandler;
        private readonly GetCarByIdCommandHandler _getCarByIdCommandHandler;
        private readonly GetCarCommandHandler _getCarCommandHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;

        

        public CarController(GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,CreateCarCommandHandler createCommandHandler, UpdateCarCommandHandler updateCommandHandler, RemoveCarCommandHandler removeCommandHandler, GetCarByIdCommandHandler getCarByIdCommandHandler, GetCarCommandHandler getCarCommandHandler)
        {
            _createCommandHandler = createCommandHandler;
            _updateCommandHandler = updateCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _getCarByIdCommandHandler = getCarByIdCommandHandler;
            _getCarCommandHandler = getCarCommandHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getCarCommandHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCar(int Id)
        {
            var value = await _getCarByIdCommandHandler.Handle(new GetCarByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("Araba başarı ile eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int Id)
        {
            await _removeCommandHandler.Handle(new RemoveCarCommand(Id));
            return Ok("Araba bilgisi başarı ile silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCommandHandler.Handle(command);
            return Ok("Bilgi Başarı ile güncellendi");
        }
        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var values = _getCarWithBrandQueryHandler.Handle();
            return Ok(values);
        }
    }
}
