using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {    private readonly CarBookContext _context;

        public CarRepository(CarBookContext context)
        {
            _context = context;
        }


        public async Task<List<Car>> GetCarWithBrandAsync()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async  Task<List<Car>> GetLast5CarsWithBrands()
        {
            return await _context.Cars
                                 .Include(x => x.Brand)
                                 .OrderByDescending(x => x.CarID)
                                 .Take(5)
                                 .ToListAsync();
        }//burda db den beş araba sorgusu
    }
}
