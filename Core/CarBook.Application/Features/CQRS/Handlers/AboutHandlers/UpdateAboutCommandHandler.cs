using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _IRepository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _IRepository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var values = await _IRepository.GetByIdAsync(command.AboutId);
            values.Title = command.Title;
            values.Description = command.Description;
            values.ImageUrl = command.ImageUrl;
            await _IRepository.UpdateAsync(values);
        }
    }
}
