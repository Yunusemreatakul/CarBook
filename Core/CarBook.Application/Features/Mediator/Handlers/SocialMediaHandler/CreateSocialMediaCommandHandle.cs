﻿using CarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
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
    public class CreateSocialMediaCommandHandle : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _socialMediaRepository;

        public CreateSocialMediaCommandHandle(IRepository<SocialMedia> socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            await _socialMediaRepository.CreateAsync(new SocialMedia
            {
                Icon = request.Icon,
                Name = request.Name,
                Url = request.Url,
            });
        }
    }
}
