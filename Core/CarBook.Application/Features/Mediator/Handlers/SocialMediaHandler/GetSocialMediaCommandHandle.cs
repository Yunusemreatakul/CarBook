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
    public class GetSocialMediaCommandHandle : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaCommandHandle(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult
            {
               Icon = x.Icon,
               Name = x.Name,
               SocialMediaId = x.SocialMediaId,
               Url=x.Url,
            }).ToList();
        }
    }
}
