using CarBook.Application.Features.Mediator.Queries.SocialMediaQuery;
using CarBook.Application.Features.Mediator.Results.SocialMediaResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandler
{
    public class GetSocialMediaByIdCommandHandle : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdCommandHandle(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                Icon = value.Icon,
                Name = value.Name,
                SocialMediaId = value.SocialMediaId,
                Url = value.Url,
            };
        }
    }
}
