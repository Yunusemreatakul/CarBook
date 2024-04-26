using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;
        private readonly GetBrandCommandHandler _getBrandCommandHandler;
        private readonly GetBrandByIdCommandHandler _getBrandByIdCommandHandler;

        public BrandController(CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler, GetBrandCommandHandler getBrandCommandHandler, GetBrandByIdCommandHandler getBrandByIdCommandHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
            _getBrandCommandHandler = getBrandCommandHandler;
            _getBrandByIdCommandHandler = getBrandByIdCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandCommandHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBrand(int Id)
        {
            var value = await _getBrandByIdCommandHandler.Handle(new GetBrandByIdQuery(Id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int Id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(Id));
            return Ok( "Değer Başarı İle silindi");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createBrandCommandHandler.Handle(command);
            return Ok("Değer eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateBrandCommandHandler.Handle(command);
            return Ok("Değer Güncellendi");
        }
             
    }
}
