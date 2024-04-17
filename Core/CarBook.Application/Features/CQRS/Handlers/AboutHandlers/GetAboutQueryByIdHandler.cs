using CarBook.Application.Features.CQRS.Queries.AboutQueries;
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
    public class GetAboutQueryByIdHandler
    {
        private readonly IRepository<About> _IRepository;

        public GetAboutQueryByIdHandler(IRepository<About> ıRepository)
        {
            _IRepository = ıRepository;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values =await _IRepository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Title = values.Title,
                Description = values.Description,
                ImageUrl = values.ImageUrl,

            };
        }
    }
}
