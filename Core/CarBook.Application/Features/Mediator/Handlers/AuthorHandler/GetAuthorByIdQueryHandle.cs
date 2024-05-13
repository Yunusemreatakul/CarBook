using CarBook.Application.Features.Mediator.Queries.AuthorQuery;
using CarBook.Application.Features.Mediator.Results.AuthorResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AuthorHandler
{
    public class GetAuthorByIdQueryHandle : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _rerpossitorry;

        public GetAuthorByIdQueryHandle(IRepository<Author> rerpossitorry)
        {
            _rerpossitorry = rerpossitorry;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _rerpossitorry.GetByIdAsync(request.Id);
            return new GetAuthorByIdQueryResult
            {
                AuthorId = value.AuthorId,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
            };
        }
    }
}
