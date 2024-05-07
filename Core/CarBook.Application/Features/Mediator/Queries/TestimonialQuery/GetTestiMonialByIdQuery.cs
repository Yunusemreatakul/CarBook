using CarBook.Application.Features.Mediator.Results.TestimonialResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.TestimonialQuery
{
    public class GetTestiMonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTestiMonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
