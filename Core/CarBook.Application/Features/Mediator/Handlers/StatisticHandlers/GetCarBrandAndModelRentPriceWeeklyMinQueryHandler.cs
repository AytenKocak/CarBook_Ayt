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
    public class GetCarBrandAndModelRentPriceWeeklyMinQueryHandler : IRequestHandler<GetCarBrandAndModelRentPriceWeeklyMinQuery, GetCarBrandAndModelRentPriceWeeklyMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelRentPriceWeeklyMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public  async Task<GetCarBrandAndModelRentPriceWeeklyMinQueryResult> Handle(GetCarBrandAndModelRentPriceWeeklyMinQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModelRentPriceWeeklyMin();
            return new GetCarBrandAndModelRentPriceWeeklyMinQueryResult{
               
            };  

        }
    }
}
