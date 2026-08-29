using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountSmallerThan1000QueryHandler : IRequestHandler<GetCarCountSmallerThan1000Query, GetCarCountSmallerThan1000QueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountSmallerThan1000QueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountSmallerThan1000QueryResult> Handle(GetCarCountSmallerThan1000Query request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountSmallerThan1000();
            return new GetCarCountSmallerThan1000QueryResult
            {
               CarCountSmallerThan1000= value
            };
        }
    }
}
