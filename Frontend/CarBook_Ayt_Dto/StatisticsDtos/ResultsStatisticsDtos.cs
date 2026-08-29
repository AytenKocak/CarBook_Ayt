using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_Ayt_Dto.StatisticsDtos
{
    public class ResultsStatisticsDtos
    {
        public int carCount { get; set; }
        public int BrandCount { get; set; }
        public int blogCount { get; set; }
        public int authourCount { get; set; }
        public int locationCount { get; set; }

        public int carCountByTransmissionIsAuto { get; set; }
        public int CarCountByGasolineOrDisel { get; set; }
        public int CarCountByElectiric { get; set; }
        public int CarCountSmallerThan1000 { get; set; }

        public decimal avrgRentPriceForDaily { get; set; }
        public decimal avrgRentPriceForWeekly { get; set; }
        public decimal avrgRentPriceForMountly { get; set; }

        public decimal CarBrandAndModelRentPriceDaily { get; set; }
        public decimal CarBrandAndModelRentPriceWeeklyMin { get; set; }
        public decimal CarBrandAndModelRentPriceMountlyMax { get; set; }

        public string BrandNameByMaxCar { get; set; }
       public string BlogTitleByMaxComment { get; set; }
     
    }
}
