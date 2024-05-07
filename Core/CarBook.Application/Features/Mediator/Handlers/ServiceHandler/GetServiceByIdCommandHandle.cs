using CarBook.Application.Features.Mediator.Queries.ServiceQuery;
using CarBook.Application.Features.Mediator.Results.ServiceResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ServiceHandler
{
    public class GetServiceByIdCommandHandle : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdCommandHandle(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                Description = value.Description,
                IconUrl = value.IconUrl,
                ServiceId = value.ServiceId,
                Title = value.Title,
            };
        }
    }
}
