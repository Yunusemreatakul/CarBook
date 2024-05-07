using CarBook.Application.Features.Mediator.Queries.PricingQuery;
using CarBook.Application.Features.Mediator.Results.PricingResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.PricingHandler
{
    public class GetPricingByIdCommandHandler : IRequestHandler<GetPricingByIdQuery,GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                Name = value.Name,
                PricingId = value.PricingId,
            };
        }
    }
}
