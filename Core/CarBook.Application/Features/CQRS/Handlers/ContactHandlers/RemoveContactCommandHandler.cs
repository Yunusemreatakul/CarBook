using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public RemoveContactCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task Handle(RemoveContactCommand command)
        {
            var value = await _contactRepository.GetByIdAsync(command.Id);
            await _contactRepository.RemoveAsync(value);
        }
    }
}
