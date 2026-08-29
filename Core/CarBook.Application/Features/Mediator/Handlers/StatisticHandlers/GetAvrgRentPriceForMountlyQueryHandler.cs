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
    public class GetAvrgRentPriceForMountlyQueryHandler : IRequestHandler<GetAvrgRentPriceForMountlyQuery, GetAvrgRentPriceForMountlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvrgRentPriceForMountlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvrgRentPriceForMountlyQueryResult> Handle(GetAvrgRentPriceForMountlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvrgRentPriceForMountly();
            return new GetAvrgRentPriceForMountlyQueryResult
            {

                AvrgRentPriceForMountly = value
            };

        }



      
    }
}
