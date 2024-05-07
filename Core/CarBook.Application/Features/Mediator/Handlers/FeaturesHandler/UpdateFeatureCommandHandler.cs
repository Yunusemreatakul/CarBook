using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> _featureRepository;

        public UpdateFeatureCommandHandler(IRepository<Feature> featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await _featureRepository.GetByIdAsync(request.FeatureId);
            values.Name = request.Name;
            await _featureRepository.UpdateAsync(values);
        }
    }
}
