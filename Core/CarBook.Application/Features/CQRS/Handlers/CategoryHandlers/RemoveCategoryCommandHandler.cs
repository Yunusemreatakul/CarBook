using CarBook.Application.Features.CQRS.Commands.CategoryCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public RemoveCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _categoryRepository.GetByIdAsync(command.Id);
            await _categoryRepository.RemoveAsync(value);
        }
    }
}
