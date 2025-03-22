using CommonExtensions.MathExtensions;
using RentOrBuy.Home.DataModel.RentCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.RentalComputations.TotalRentalCostComputation
{
    public class TotalRentalCostCalculator : ITotalRentalCostCalculator
    {
        public TotalRentalCost CalculateTotalRentalCost(List<RentCostEachYear> rentCostEachYear)
        {
            var totalRentalCost = new TotalRentalCost();
            var totalRentalInsurance = 0m;
            var totalRent = 0m;

            foreach (var rentCostForCurrentYear in rentCostEachYear)
            {
                totalRentalInsurance += rentCostForCurrentYear.RentalInsurance;
                totalRent += rentCostForCurrentYear.Rent;
            }

            totalRentalCost.TotalRentalInsurance = totalRentalInsurance.RoundToTwoDecimalPlaces();
            totalRentalCost.TotalRent = totalRent.RoundToTwoDecimalPlaces();

            return totalRentalCost;
        }
    }
}
