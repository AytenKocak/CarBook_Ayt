using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithPricingQueryHandler
    {
        private readonly ICarPricingRepository _repository;

        public GetCarWithPricingQueryHandler(ICarPricingRepository repository)
        {
            _repository = repository;
        }

        public async Task< List<GetCarWithPricingQueryResult>> Handle()
        {
            var values = await _repository.GetCarPricingWithCar();

            return values.Select(y => new GetCarWithPricingQueryResult
            {
                Model=y.Car.Model,
                BrandID=y.Car.BrandID,
                CoverImageUrl=y.Car.CoverImageUrl,
                BrandName=y.Car.Brand.Name,
               PricingAmount=y.Amount,


            }).ToList();
        }


     
            
      


        
    }
}

