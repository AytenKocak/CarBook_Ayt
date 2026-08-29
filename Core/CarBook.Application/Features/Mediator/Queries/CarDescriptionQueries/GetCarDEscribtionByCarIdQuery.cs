using CarBook.Application.Features.Mediator.Results.CarDescribtionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDEscribtionByCarIdQuery:IRequest<GetCarDEscribtionQueryResult>
    {
        public int Id { get; set; }

        public GetCarDEscribtionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
