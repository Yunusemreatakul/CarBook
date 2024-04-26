using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _BrandRepository;

        public RemoveBrandCommandHandler(IRepository<Brand> brandRepository)
        {
            _BrandRepository = brandRepository;
        }
        public async Task Handle(RemoveBrandCommand command)
        {
            var value = await _BrandRepository.GetByIdAsync(command.Id);
            await _BrandRepository.RemoveAsync(value);
        }
    }
}
