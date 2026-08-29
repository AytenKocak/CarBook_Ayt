using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarBookContext _context;

        public CarDescriptionRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<CarDescription?> GetCarDescriptionAsync(int carId)
        {
            return await _context.CarDescriptions
                .FirstOrDefaultAsync(x => x.CarID == carId);
        }
    }
}
