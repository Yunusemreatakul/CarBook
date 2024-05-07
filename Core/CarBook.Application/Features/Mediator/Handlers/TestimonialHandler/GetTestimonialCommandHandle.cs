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
    public class GetTestimonialCommandHandle : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialCommandHandle(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                Comment = x.Comment,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                TestimonialId = x.TestimonialId,
                Title = x.Title
            }).ToList();
        }
    }
}
