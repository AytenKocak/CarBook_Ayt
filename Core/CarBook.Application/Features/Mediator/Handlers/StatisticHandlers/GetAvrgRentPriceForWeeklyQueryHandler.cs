using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAvrgRentPriceForWeeklyQueryHandler : IRequestHandler<GetAvrgRentPriceForWeeklyQuery, GetAvrgRentPriceForWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvrgRentPriceForWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async  Task<GetAvrgRentPriceForWeeklyQueryResult> Handle(GetAvrgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
           var value=_repository.GetAvrgRentPriceForWeekly();
            return new GetAvrgRentPriceForWeeklyQueryResult
            {
                AvrgRentPriceForWeekly = value
            };  
        }
    }
}
