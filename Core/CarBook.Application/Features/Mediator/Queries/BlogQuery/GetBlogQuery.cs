﻿using CarBook.Application.Features.Mediator.Results.BlogResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogQuery
{
    public class GetBlogQuery : IRequest<List<GetBlogQueryResult>>
    {
    }
}
