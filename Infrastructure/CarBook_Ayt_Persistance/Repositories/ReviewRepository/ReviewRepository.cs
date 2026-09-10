using CarBook.Application.Features.Mediator.Handlers.CommentHandlers;
using CarBook.Application.Interfaces.ReviewRepository;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository

    {
        private readonly CarBookContext _context;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        

        public async Task<List<Review>> GetReviewsByCarIdAsync(int carId)
        {
            var values = _context.Reviews.Where(x => x.CarID == carId).ToList();
            return values;
        }
    }
}
