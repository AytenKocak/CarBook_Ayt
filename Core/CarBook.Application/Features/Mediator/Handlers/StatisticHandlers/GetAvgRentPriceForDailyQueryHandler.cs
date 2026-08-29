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
    public class GetAvrgRentPriceForDailyQueryHandler : IRequestHandler<GetAvrgRentPriceForDailyQuery, GetAvrgRentPriceForDailyQueryResult>
        
    {
        private readonly IStatisticsRepository _repository;

        public GetAvrgRentPriceForDailyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async  Task<GetAvrgRentPriceForDailyQueryResult> Handle(GetAvrgRentPriceForDailyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvrgRentPriceForDaily();
            return new GetAvrgRentPriceForDailyQueryResult
            {
                AvrgRentPriceForDaily = value
            };
        }
    }
}
