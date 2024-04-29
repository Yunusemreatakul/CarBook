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
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _categoryRepository;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var value = await _categoryRepository.GetByIdAsync(command.CategoryId);
            value.Name = command.Name;
            await _categoryRepository.UpdateAsync(value);
        }
    }
}
