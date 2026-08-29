using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.CarPricingsResults
{
    public class GetCarPricingWithTimePeriodResult
    {
        public string Model { get; set; }
        public Decimal  DailyAmount { get; set; }
        public Decimal WeeeklyAmount { get; set; }
        public Decimal  MountlyAmount { get; set; }
        public string BrandName { get; set; }
        public string CoverImageUrl { get; set; }
    }
}
