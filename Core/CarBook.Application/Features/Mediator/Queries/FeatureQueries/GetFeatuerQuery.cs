using CarBook.Application.Features.Mediator.Results.Feature;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatuerQuery :IRequest<List<GetFeatureQueryResult>>
    {
    }
}
