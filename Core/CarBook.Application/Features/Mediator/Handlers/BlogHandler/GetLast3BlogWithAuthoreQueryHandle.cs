using CarBook.Application.Features.Mediator.Queries.BlogQuery;
using CarBook.Application.Features.Mediator.Results.BlogResult;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandler
{
    public class GetLast3BlogWithAuthoreQueryHandle : IRequestHandler<GetLast3BlogWithAuthorsQuery, List<GetLast3BlogWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _blogRepository;

        public GetLast3BlogWithAuthoreQueryHandle(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogWithAuthorQueryResult>> Handle(GetLast3BlogWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values =  _blogRepository.GetLast3BlogWithAuthor();
            return values.Select(
                x => new GetLast3BlogWithAuthorQueryResult
                {
                   AuthorId = x.AuthorId,
                   AuthorName=x.Author.Name,
                   BlogId=x.BlogId,
                   CategoryId=x.CategoryId,
                   CoverImageUrl    =x.CoverImageUrl,
                   CreateDate = x.CreateDate,
                   Title=x.Title,
                }).ToList();
        }
    }
}
