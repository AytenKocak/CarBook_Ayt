using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarBook_Ayt_Persistance.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<CarPricing>> GetCarPricingWithCar()
        {
            var values = await _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(y => y.Brand)
                .Include(x => x.Pricing)
                .Where(x => x.PricingID == 2)
                .ToListAsync();

            return values;
        }

        public Task<List<CarPricing>> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = @"
                    SELECT *
                    FROM
                    (
                        SELECT
                            Brands.Name,
                            Cars.Model,
                            Cars.CoverImageUrl,
                            CarPricings.PricingID,
                            CarPricings.Amount
                        FROM CarPricings
                        INNER JOIN Cars ON Cars.CarID = CarPricings.CarID
                        INNER JOIN Brands ON Brands.BrandID = Cars.BrandID
                    ) AS SourceTable
                    PIVOT
                    (
                        SUM(Amount)
                        FOR PricingID IN ([1],[2],[3])
                    ) AS PivotTable";

                command.CommandType = System.Data.CommandType.Text;

                await _context.Database.OpenConnectionAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel
                        {
                            BrandName = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString()
                        };

                     //haftalık aylık fiyatlar sıra ile
                        carPricingViewModel.Amounts.Add(
                            reader["1"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["1"]));

                     
                        carPricingViewModel.Amounts.Add(
                            reader["2"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["2"]));

             
                        carPricingViewModel.Amounts.Add(
                            reader["3"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["3"]));

                        values.Add(carPricingViewModel);
                    }
                }

                await _context.Database.CloseConnectionAsync();
            }

            return values;
        }
    }
}