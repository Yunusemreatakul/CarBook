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
    public class GetContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public GetContactCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<List<GetContactQueryResults>> Handle()
        {
            var values = await _contactRepository.GetAllAsync();
            return values.Select(x => new GetContactQueryResults
            {
                ContactId = x.ContactId,
                Email = x.Email,
                Message = x.Message,
                Name = x.Name,
                SendDate = x.SendDate,  
                Subject = x.Subject,
            }).ToList();
        }
    }
}
