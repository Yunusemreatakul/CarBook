using CarBook.Application.Features.Mediator.Queries.LocationQuery;
using CarBook.Application.Features.Mediator.Results.LocationResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.LocationHandler
{
    public class GetLocationByIdCommandHandle : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _locationRepository;

        public GetLocationByIdCommandHandle(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _locationRepository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
                LocationId = value.LocationId,
                Name = value.Name,
            };
        }
    }
}
