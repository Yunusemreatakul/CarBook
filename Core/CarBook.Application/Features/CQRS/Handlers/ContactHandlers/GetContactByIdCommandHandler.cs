using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public GetContactByIdCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<GetContactByIdQuersResult> Handle(GetContactByIdQuery command)
        {
            var value = await _contactRepository.GetByIdAsync(command.Id);
            return new GetContactByIdQuersResult
            {
                ContactId = value.ContactId,
                Email = value.Email,
                Message = value.Message,
                Name = value.Name,
                SendDate = value.SendDate,
                Subject = value.Subject,
            };
        }
    }
}
