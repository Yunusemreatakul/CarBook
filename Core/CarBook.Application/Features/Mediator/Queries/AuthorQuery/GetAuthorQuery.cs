using CarBook.Application.Features.Mediator.Results.AuthorResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AuthorQuery
{
    public class GetAuthorQuery: IRequest<List<GetAuthorQueryResult>>
    {
    }
}
