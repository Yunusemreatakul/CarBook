using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly GetCategoryByIdQueryHandler _GetCategoryByIdHandler;
        private readonly GetCategoryQueryHandler _GetCategoryQueryHandler;
        private readonly CreateCategoryCommandHandler _CreateCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _UpdateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _RemoveCategoryCommandHandler;

        public CategoryController(GetCategoryByIdQueryHandler getCategoryByIdHandler, GetCategoryQueryHandler getCategoryQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _GetCategoryByIdHandler = getCategoryByIdHandler;
            _GetCategoryQueryHandler = getCategoryQueryHandler;
            _CreateCategoryCommandHandler = createCategoryCommandHandler;
            _UpdateCategoryCommandHandler = updateCategoryCommandHandler;
            _RemoveCategoryCommandHandler = removeCategoryCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _GetCategoryQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategory(int Id)
        {
            var value =await _GetCategoryByIdHandler.Handle(new GetCategoryByIdQuery(Id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            await _CreateCategoryCommandHandler.Handle(command);
            return Ok("Category Başarılı Şekilde Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command)
        {
            await _UpdateCategoryCommandHandler.Handle(command);
            return Ok("Category Güncelleme İşlemi Bşarılı");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(RemoveCategoryCommand command)
        {
            await _RemoveCategoryCommandHandler.Handle(command);
            return Ok("Category Başrılı şekilde silindi");
        }
    }
}
