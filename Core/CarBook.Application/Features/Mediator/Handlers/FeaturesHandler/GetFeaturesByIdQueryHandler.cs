using CarBook.Application.Features.Mediator.Queries.FeatureQuery;
using CarBook.Application.Features.Mediator.Results.FeatureResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FeaturesHandler
{
    public class GetFeaturesByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _FeaturesRepository;

        public GetFeaturesByIdQueryHandler(IRepository<Feature> featuresRepository)
        {
            _FeaturesRepository = featuresRepository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _FeaturesRepository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResult
            {
                FeatureId = value.FeatureId,
                Name = value.Name,
            };
        }
    }
}
