using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.TagCloudRepository
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarBookContext _context;

        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public async  Task<List<TagCloud>> GetTagCloudListByBlogId(int id)
        {
            return await _context.TagClouds
                .Where(x => x.BlogID == id)
                .ToListAsync();
        }
    }
}
