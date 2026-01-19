using CarBook.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarBook_Ayt_Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarBookContext _context;

        public Repository(CarBookContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public Task<List<T>> GetAllAsync()
        {
           return _context.Set<T>().ToListAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            return _context.Set<T>().FindAsync(id).AsTask();
        }

        public Task RemoveAsync(T entity)
        {
           _context.Set<T>().Remove(entity);
              return _context.SaveChangesAsync();

        }

      

        public Task UpdateAsync(T entity)
        {
           _context.Set<T>().Update(entity);
              return _context.SaveChangesAsync();

        }
    }
}

