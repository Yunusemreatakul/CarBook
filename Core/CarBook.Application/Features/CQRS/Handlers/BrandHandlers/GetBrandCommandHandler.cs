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
    public class GetBrandCommandHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandCommandHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<List<GetBrandQueryResults>> Handle()
        {
            var values =await _brandRepository.GetAllAsync();
            return values.Select(x => new GetBrandQueryResults
            {
                BrandId = x.BrandId,
                Name = x.Name,
            }).ToList();
        }
    }
}
