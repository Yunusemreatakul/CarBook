using CarBook.Application.Features.Mediator.Commands.BlogCommands;
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
    public class UpdateBlogCommandHandle : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandle(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.BlogId);
            value.CreateDate = request.CreateDate;
            value.CoverImageUrl = request.CoverImageUrl;
            value.Title = request.Title;
            value.CategoryId = request.CategoryId;
            value.AuthorId = request.AuthorId;
            value.BlogId = request.BlogId;
            await _repository.UpdateAsync(value);
        }
    }
}
