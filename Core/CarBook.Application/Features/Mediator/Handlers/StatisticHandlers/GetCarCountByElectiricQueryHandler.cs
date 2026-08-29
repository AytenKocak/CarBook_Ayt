using CarBook.Application.Features.Mediator.Queries;
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
    public class GetCarCountByElectiricQueryHandler : IRequestHandler<GetCarCountByElectiricQuery, GetCarCountByElectiricQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarCountByElectiricQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByElectiricQueryResult> Handle(GetCarCountByElectiricQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByElectiric();
            return new GetCarCountByElectiricQueryResult
            {
               CarCountByElectiric=value
            };
        }
    }
}
