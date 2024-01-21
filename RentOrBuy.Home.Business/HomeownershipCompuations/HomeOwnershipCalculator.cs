using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonExtensions.MathExtensions;

namespace RentOrBuy.Home.Business.HomeownershipCompuations
{
    public class HomeOwnershipCalculator : IHomeOwnershipCalculator
    {
        public Dictionary<ushort, decimal> CalculateHomeOwnershipCost(OwnershipCostFactors ownershipCosts)
        {
            var ownershipCostPerYear = new Dictionary<ushort, decimal>();
            CalculateTotalCostForYearZero(ownershipCosts, ownershipCostPerYear);
            return ownershipCostPerYear;
        }

        private void CalculateOwnershipCostForEachYear(OwnershipCostFactors ownershipCosts,
            Dictionary<ushort, decimal> ownershipCostsPerYear)
        {
            CalculateTotalCostForYearZero(ownershipCosts, ownershipCostsPerYear);
            for (var i = 1; i <= ownershipCosts.PlannedLengthOfStay; i++)
            {
                //var projectedPriceThisYear = cost of mortgage interest + cost of maintenance + cost of home insurance +
                //excess utilities + common fees + property tax
            }
        }

        private void  CalculateTotalCostForYearZero(OwnershipCostFactors ownershipCosts,
            Dictionary<ushort, decimal> ownershipCostPerYear)
        {
            var downPayment = (ownershipCosts.DownPaymentPercentage * ownershipCosts.Price).RoundToTwoDecimalPlaces();
            var closingCost = (ownershipCosts.ClosingCostWhenBuying * ownershipCosts.Price).RoundToTwoDecimalPlaces();
            ownershipCostPerYear[0] = downPayment + closingCost;
        }
    }
}
