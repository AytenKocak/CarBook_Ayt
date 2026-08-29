using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.StatisticsInterfaces
{
    public interface IStatisticsRepository
    {
        int GetLocationCount();
        int GetCarCount();
        int GetAuthourCount();
        int GetBlogCount();
        int GetBrandCount();
        decimal GetAvrgRentPriceForDaily();
        decimal GetAvrgRentPriceForWeekly();
        decimal GetAvrgRentPriceForMountly();
        int GetCarCountByTransmissionIsAuto();
        string GetBrandNameByMaxCar();
        string GetBlogTitleByMaxComment();
        int GetCarCountSmallerThan1000();
        int GetCarCountByGasolineOrDisel();
        int GetCarCountByElectiric();
        decimal GetCarBrandAndModelRentPriceMountlyMax();
        decimal GetCarBrandAndModelRentPriceWeeklyMin();
        decimal GetCarBrandAndModelRentPriceDaily();
        object GetBlogCountQueryX();
    }
}
