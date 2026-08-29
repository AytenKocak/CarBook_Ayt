using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;


namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarCountByGasolineOrDiselQueryHandler : IRequestHandler<GetCarCountByGasolineOrDiselQuery, GetCarCountByGasolineOrDiselQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByGasolineOrDiselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async  Task<GetCarCountByGasolineOrDiselQueryResult> Handle(GetCarCountByGasolineOrDiselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByGasolineOrDisel();
            return new GetCarCountByGasolineOrDiselQueryResult
            {
               CarCountByGasolineOrDisel=value

            };
        }
    }
}
