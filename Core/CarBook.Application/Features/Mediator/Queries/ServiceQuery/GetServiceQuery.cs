﻿using CarBook.Application.Features.Mediator.Results.ServiceResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ServiceQuery
{
    public class GetServiceQuery: IRequest<List<GetServiceQueryResult>>
    {
    }
}
