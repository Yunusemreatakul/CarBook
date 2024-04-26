using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdCommandHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandByIdCommandHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<GetBrandByIdQueryResults> Handle(GetBrandByIdQuery command)
        {
            var value = await _brandRepository.GetByIdAsync(command.Id);
            return new GetBrandByIdQueryResults
            {
                BrandId = value.BrandId,
                Name = value.Name,
            };
        }
    }
}
