using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingsResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodResult>>
    {
        private readonly ICarPricingRepository _repository;

        public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPricingWithTimePeriodResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
           var values=await _repository.GetCarPricingWithTimePeriod1();
            return values.Select(x => new GetCarPricingWithTimePeriodResult
            {  BrandName = x.BrandName,
              CoverImageUrl = x.CoverImageUrl,
                Model = x.Model,
                DailyAmount = x.Amounts[0],
                WeeeklyAmount = x.Amounts[1],
                MountlyAmount = x.Amounts[2]
            }).ToList();


        }
    }
}
