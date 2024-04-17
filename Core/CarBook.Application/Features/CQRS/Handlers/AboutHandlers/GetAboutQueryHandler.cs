using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IRepository<About> _IRepository;

        public GetAboutQueryHandler(IRepository<About> ıRepository)
        {
            _IRepository = ıRepository;
        }
        public async Task<List<GetAboutQueryResult>> Handler()
        {
            var values =await _IRepository.GetAllAsync();
            return values.Select(x => new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
            }).ToList();
        }
    }
}
