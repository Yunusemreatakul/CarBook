﻿using CarBook.Application.Features.Mediator.Queries.AuthorQuery;
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
    public class GetAuthorQueryHandle : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandle(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAuthorQueryResult { 
                AuthorId = x.AuthorId,
                Description=x.Description,
                ImageUrl = x.ImageUrl,
                Name=x.Name,
            }).ToList();
        }
    }
}