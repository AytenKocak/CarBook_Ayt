using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Persistance.Repositories.TagCloudepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {  private readonly CarBookContext _context;

        public TagCloudRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudByBlogId(int id)
        {
            var values= _context.TagClouds.Where(x=>x.BlogID == id).ToList();   
            return values;
        }
    }
}
