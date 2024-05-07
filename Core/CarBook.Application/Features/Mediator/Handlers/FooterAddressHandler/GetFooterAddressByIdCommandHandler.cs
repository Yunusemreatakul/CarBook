using CarBook.Application.Features.Mediator.Queries.FooterAddressQuery;
using CarBook.Application.Features.Mediator.Results.FooterAddressResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.FooterAddressHandler
{
    public class GetFooterAddressByIdCommandHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _footerAddressRepository;

        public GetFooterAddressByIdCommandHandler(IRepository<FooterAddress> footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _footerAddressRepository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                Address = value.Address,
                Description = value.Description,
                Email = value.Email,
                FooterAddressId = value.FooterAddressId,
                PhoneNumber = value.PhoneNumber,
            };
        }
    }
}
