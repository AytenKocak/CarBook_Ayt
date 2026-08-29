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
    public class GetAuthourCountQueryHandler : IRequestHandler<GetAuthourCountQuery, GetAuthourCountQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAuthourCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthourCountQueryResult> Handle(GetAuthourCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAuthourCount();
            return new GetAuthourCountQueryResult
            {  AuthourCount = value
            };
        }
    }
}
