using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly GetBannerQueryHandler _BannerqueryHandler;
        private readonly GetBannerByIdQueryHandler _BannerByIdqueryHandler;
        private readonly CreateBannerCommandHandler _CreateBannerCommandHandler;
        private readonly RemoveBannerCommandHandler _RemoveBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _UpdateBannerCommandHandler;

        public BannerController(GetBannerQueryHandler bannerqueryHandler, GetBannerByIdQueryHandler bannerByIdqueryHandler, CreateBannerCommandHandler createBannerCommandHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            _BannerqueryHandler = bannerqueryHandler;
            _BannerByIdqueryHandler = bannerByIdqueryHandler;
            _CreateBannerCommandHandler = createBannerCommandHandler;
            _RemoveBannerCommandHandler = removeBannerCommandHandler;
            _UpdateBannerCommandHandler = updateBannerCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _BannerqueryHandler.Handler();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBanner(int id)
        {
            var value = await _BannerByIdqueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _CreateBannerCommandHandler.Handle(command);
            return Ok("Bilgi Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommands command)
        {
            await _UpdateBannerCommandHandler.Handle(command);
            return Ok("Bilgi düzenlendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _RemoveBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok(" Bilgi silindi");
            
        }
    }
}
