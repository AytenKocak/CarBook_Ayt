using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Dto.CarPricingDtos
{
    public class CarPricingListWithModelDto
    {
        public string Model { get; set; }
        public decimal DailyAmount { get; set; }
        public decimal WeeeklyAmount { get; set; }
        public decimal MountlyAmount { get; set; }
        public string CoverImageUrl { get; set; }
        public string Brand { get; set; }
    }
}
