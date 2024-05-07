using CarBook.Application.Features.Mediator.Queries.TestimonialQuery;
using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.TestimonialHandler
{
    public class GetTestimonialByIdCommandHandle : IRequestHandler<GetTestiMonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdCommandHandle(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestiMonialByIdQuery request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQueryResult
            {
                Comment = value.Comment,
                ImageUrl = value.ImageUrl,
                Name = value.Name,
                TestimonialId = value.TestimonialId,
                Title = value.Title,
            };
        }
    }
}
