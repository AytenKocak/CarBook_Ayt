using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetCarWithBrandAsync();
            return values.Select(x => new GetCarQueryResult
            {
                CarID = x.CarID,
                BigImageUrl=x.BigImageUrl,
                BrandID = x.BrandID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel=x.Fuel,
                Km=x.Km,
                Transmission=x.Transmission,
                Seat=x.Seat,
                Model=x.Model,
               Luggage=x.Luggage,
               BrandName = x.Brand.Name


            }).ToList();

        }
    }
}