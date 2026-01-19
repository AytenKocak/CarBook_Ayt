using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetCarWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {  BrandName = x.Brand.Name,
                CarID = x.CarID,
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Model = x.Model,
                Luggage = x.Luggage,
            }).ToList();
        }
    }
}
