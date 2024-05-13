using CarBook.Application.Features.Mediator.Queries.BlogQuery;
using CarBook.Application.Features.Mediator.Results.BlogResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class GetBlogByIdCommandHandle : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdCommandHandle(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                BlogId = value.BlogId,
                AuthorId = value.AuthorId,
                CategoryId = value.CategoryId,
                CoverImageUrl = value.CoverImageUrl,
                CreateDate = value.CreateDate,
                Title = value.Title,
            };
        }
    }
}
