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
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _FeaturesRepository;

        public GetFeatureQueryHandler(IRepository<Feature> featuresRepository)
        {
            _FeaturesRepository = featuresRepository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _FeaturesRepository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult { FeatureId = x.FeatureId,Name=x.Name }).ToList();
        }
    }
}
