using CarBook.Application.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewByCarIdQuery:IRequest<List<GetReviewByCarIdQueryResults>>
    {
        public int Id { get; set; }

        public GetReviewByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
