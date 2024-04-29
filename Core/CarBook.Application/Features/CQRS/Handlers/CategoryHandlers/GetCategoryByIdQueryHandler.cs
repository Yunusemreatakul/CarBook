using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public GetCategoryByIdQueryHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryByIdQueryResults> Handle(GetCategoryByIdQuery command)
        {
            var value =await _categoryRepository.GetByIdAsync(command.Id);
            return new GetCategoryByIdQueryResults
            {
                Name = value.Name,
                CategoryId = value.CategoryId,
            };
        }
    }
}
