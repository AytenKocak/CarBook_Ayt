using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    { private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCar()
        {
            var values = await _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(y => y.Brand)
                .Include(z => z.Pricing)
                .Where (x=>x.PricingID==2)
                .ToListAsync();

            return values;
        }
    }
}
