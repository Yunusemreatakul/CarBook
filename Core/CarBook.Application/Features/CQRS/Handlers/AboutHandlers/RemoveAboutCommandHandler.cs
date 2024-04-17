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
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _IRepository;
        public RemoveAboutCommandHandler(IRepository<About> repository)
        {
            _IRepository = repository;
        }
        public async Task Handler(RemoveAboutCommand command)
        {
            var remove =await _IRepository.GetByIdAsync(command.Id);
            await _IRepository.RemoveAsync(remove);
        }
    }
}
