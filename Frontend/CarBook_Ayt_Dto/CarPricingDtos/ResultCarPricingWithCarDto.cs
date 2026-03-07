using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Dto.CarPricingDtos
{
    public class ResultCarPricingWithCarDto
    {
        public int CarID { get; set; }
        public int BrandID { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string Km { get; set; }
        public string Transmission { get; set; }
        public byte Seat { get; set; }
        public byte Luggage { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public string BrandName { get; set; }
        public string PricingName { get; set; }
        public decimal PricingAmount { get; set; }
    }
}
