using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.SocialMediaHandler
{
    public class UpdateSocialMediaCommandHandle : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public UpdateSocialMediaCommandHandle(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _socialMediaRepository.GetByIdAsync(request.SocialMediaId);
            value.SocialMediaId = request.SocialMediaId;
            value.Url   = request.Url;
            value.Icon= request.Icon;
            value.Name = request.Name;
            await _socialMediaRepository.UpdateAsync(value);
                
            
        }
    }
}
