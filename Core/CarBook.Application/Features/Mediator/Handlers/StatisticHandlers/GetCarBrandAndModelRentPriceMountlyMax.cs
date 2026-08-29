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
    public class GetCarBrandAndModelRentPriceMountlyMax : IRequestHandler<GetCarBrandAndModelRentPriceMountlyMaxQuery, GetCarBrandAndModelRentPriceMountlyMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModelRentPriceMountlyMax(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async  Task<GetCarBrandAndModelRentPriceMountlyMaxQueryResult> Handle(GetCarBrandAndModelRentPriceMountlyMaxQuery request, CancellationToken cancellationToken)
        {
           var value= _repository.GetCarBrandAndModelRentPriceMountlyMax();
            return new GetCarBrandAndModelRentPriceMountlyMaxQueryResult
            {
                
            };  
        }
    }
}
