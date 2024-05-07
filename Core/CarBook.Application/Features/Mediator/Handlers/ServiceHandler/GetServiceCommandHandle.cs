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
    public class GetServiceCommandHandle : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceCommandHandle(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                Description = x.Description,
                IconUrl = x.IconUrl,
                ServiceId = x.ServiceId,
                Title = x.Title,
            } ).ToList();
        }
    }
}
