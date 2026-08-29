using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace CarBook_Ayt_Persistance.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public string BlogTitleByMaxComment()
        {
            var value = (from b in _context.Blogs
                         join c in _context.Comments
                         on b.BlogID equals c.BlogID
                         group c by b.Title into g
                         orderby g.Count() descending
                         select g.Key).FirstOrDefault();

            return value;
        }

        public string GetBrandNameByMaxCar()
        {


        var brandName=_context.Brands
        .Where(b => _context.Cars.Count(c => c.BrandID == b.BrandID) > 0)
        .OrderByDescending(b => _context.Cars.Count(c => c.BrandID == b.BrandID))
        .Select(b => b.Name)
        .FirstOrDefault();
            return brandName;
        }
        

        public int GetAuthourCount()
        {
            var value = _context.Authors.Count();
            return value;

        }

        public decimal GetAvrgRentPriceForDaily()
        {
            int id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvrgRentPriceForMountly()
        {
            return _context.CarPricings
       .Where(x => x.PricingID == 3)
       .Average(x => x.Amount);
        }

        public decimal GetAvrgRentPriceForWeekly()
        {
            int id = _context.Pricings
                .Where(y => y.Name == "Haftalık")
                .Select(z => z.PricingID)
                .FirstOrDefault();

            var value = _context.CarPricings
                .Where(w => w.PricingID == id)
                .Average(x => x.Amount);

            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public object GetBlogCountQueryX()
        {
            throw new NotImplementedException();
        }

        public string GetBlogTitleByMaxComment()
        {
          var commentrate= _context.Blogs
       .OrderByDescending(b => _context.Comments.Count(c => c.BlogID == b.BlogID))
       .Select(b => b.Title)
       .FirstOrDefault();
            return commentrate;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }       

        public decimal GetCarBrandAndModelRentPriceDaily()
        {
            // select AVG(Amount) from CarPricings where PricingID = (select PricingID from Pricings
            //where Name = 'Günlük')

            int id = _context.Pricings.Where(x => x.Name == "Günlük").Select(z => z.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(y => y.PricingID == id).Average(x => x.Amount);
            return  value;


        }

        public decimal GetCarBrandAndModelRentPriceMountlyMax()
        {
            return _context.CarPricings
                      .Where(x => x.PricingID == 3)
                     .Max(x => x.Amount);
        }

        public decimal GetCarBrandAndModelRentPriceWeeklyMin()
        {
            return _context.CarPricings
                  .Where(x => x.PricingID == 2)
                  .OrderBy(x => x.Amount)
                  .Select(x => x.Amount)
                  .FirstOrDefault();
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByElectiric()
        {
            var value = _context.Cars.Select(x => x.Fuel=="Elektirik").Count();
            return value;
        }

        public int GetCarCountByGasolineOrDisel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik");
            return value.Count();
        }

        public int GetCarCountSmallerThan1000()
        {

            var value = _context.Cars.Where(x => Convert.ToInt32(x.Km) <= 1000).Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value= _context.Locations.Count();
            return value;


        }

      
    }
}
