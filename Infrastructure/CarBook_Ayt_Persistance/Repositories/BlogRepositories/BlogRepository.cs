using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {     private readonly CarBookContext _carbookcontext;

        public BlogRepository(CarBookContext carbookcontext)
        {
            _carbookcontext = carbookcontext;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthorsAsync()
        {
            return await _carbookcontext.Blogs
                .Include(x => x.Author)
                .OrderByDescending(x => x.CreatedDate)
                .Take(3)
                .ToListAsync();
        }
    }
}
