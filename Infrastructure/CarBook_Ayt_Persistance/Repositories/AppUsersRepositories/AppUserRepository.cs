using CarBook.Application.Interfaces.AppUserInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBook_Ayt_Persistance.Repositories.AppUsersRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarBookContext _context;

        public AppUserRepository(CarBookContext context)
        {
            _context = context;
        }

        public Task<AppUser?> GetByFilterAsync(
            Expression<Func<AppUser, bool>> filter)
        {
            return _context.AppUsers.FirstOrDefaultAsync(filter);
        }

       
    }
}