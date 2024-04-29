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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _contactRepository;

        public UpdateContactCommandHandler(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var value = await _contactRepository.GetByIdAsync(command.ContactId);
            value.SendDate = command.SendDate;
            value.Subject = command.Subject;
            value.Email = command.Email;
            value.Message = command.Message;
            value.Name = command.Name;
            await _contactRepository.UpdateAsync(value);
        }
    }
}
