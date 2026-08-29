using CarBook.Domain.Entities;
using CarBook_Ayt_Persistance.Repositories.RentACarInterfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CarBook_Ayt_Persistance.Repositories.RentACarRepositories
{
    public class RentACarRepositories : IRentACarRepository
    {private readonly CarBookContext _context;

        public RentACarRepositories(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values=await _context.RentACars.Where(filter).Include(x=> x.Car)
                .ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }
    }
}
