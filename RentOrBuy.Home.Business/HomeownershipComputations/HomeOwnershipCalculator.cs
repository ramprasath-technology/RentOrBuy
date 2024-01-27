using RentOrBuy.Home.DataModel.OwnershipCost;
using CommonExtensions.MathExtensions;
using RentOrBuy.Home.DataModel.EconomicCost;

namespace RentOrBuy.Home.Business.HomeownershipCompuations
{
    public class HomeOwnershipCalculator : IHomeOwnershipCalculator
    {
        public Dictionary<ushort, OwnershipCostEachYear> CalculateHomeOwnershipCost(OwnershipCostFactors ownershipCosts,
            EconomicCostFactors economicFactors)
        {
            var costTracker = new Dictionary<ushort, OwnershipCostEachYear>();
            InitializeOwnershipCostTracker(costTracker, ownershipCosts.PlannedLengthOfStay);
            CalculateOwnershipCostForEachYear(ownershipCosts, economicFactors, costTracker);
            return costTracker;
        }

        private void InitializeOwnershipCostTracker(Dictionary<ushort, OwnershipCostEachYear> tracker, 
            ushort lengthOfStay)
        {
            for (ushort i = 0; i < lengthOfStay; i++)
            {
                tracker[i] = new OwnershipCostEachYear();
            }
        }

        private void CalculateOwnershipCostForEachYear(OwnershipCostFactors ownershipCosts,
            EconomicCostFactors economicFactors,
            Dictionary<ushort, OwnershipCostEachYear> ownershipCostsPerYear)
        {
            CalculateCostsForYearZero(ownershipCosts, ownershipCostsPerYear);
            for (ushort i = 1; i < ownershipCostsPerYear.Count; i++)
            {
                CalculateHomeValueEachYear(ownershipCostsPerYear, ownershipCosts, i);
                CalculatePropertyTaxEachYear(ownershipCostsPerYear, ownershipCosts, i);
                CalculateMaintenanceEachYear(ownershipCostsPerYear, ownershipCosts, i);
                CalculateCommonFeeEachYear(ownershipCostsPerYear, i, economicFactors.Inflation);
                CalculateExcessUtilitiesEachYear(ownershipCostsPerYear, i, economicFactors.Inflation);
            }
        }

        private void CalculateCostsForYearZero(OwnershipCostFactors ownershipCosts,
            Dictionary<ushort, OwnershipCostEachYear> ownershipCostPerYear)
        {
            ownershipCostPerYear[0].HomeValue = ownershipCosts.Price;
            ownershipCostPerYear[0].CommonFee = ownershipCosts.MonthlyCommonFees * 12;
            ownershipCostPerYear[0].ExcessUtilities = ownershipCosts.MonthlyUtilities * 12;
            ownershipCostPerYear[0].MaintenanceCost = (ownershipCosts.Price * ownershipCosts.MaintenancePercentage).RoundToTwoDecimalPlaces();
            ownershipCostPerYear[0].HomeInsurance = (ownershipCosts.Price * ownershipCosts.HomeownerInsurancePercentage).RoundToTwoDecimalPlaces();
        }

        private void CalculateHomeValueEachYear(Dictionary<ushort, OwnershipCostEachYear> 
            ownershipCostPerYear,
            OwnershipCostFactors ownershipCosts,
            ushort year)
        {
            var value = ownershipCostPerYear[year];
            var homeValuePreviousYear = ownershipCostPerYear[(ushort)(year - 1)].HomeValue;
            var increaseThisYear = homeValuePreviousYear * ownershipCosts.AnnualPriceGrowthRate;
            var homeValueThisYear = (homeValuePreviousYear + increaseThisYear).RoundToTwoDecimalPlaces();   
            value.HomeValue = homeValueThisYear;
        }

        private void CalculatePropertyTaxEachYear(Dictionary<ushort, OwnershipCostEachYear>
            ownershipCostPerYear,
            OwnershipCostFactors ownershipCosts,
            ushort year)
        {
            var currentYear = ownershipCostPerYear[year];
            var currentHomeValue = currentYear.HomeValue;
            currentYear.PropertyTax = (currentHomeValue * ownershipCosts.PropertyTaxPercentage).RoundToTwoDecimalPlaces();
        }

        private void CalculateMaintenanceEachYear(Dictionary<ushort, OwnershipCostEachYear>
            ownershipCostPerYear,
            OwnershipCostFactors ownershipCosts,
            ushort year)
        {
            var currentYear = ownershipCostPerYear[year];
            var currentHomeValue = currentYear.HomeValue;
            currentYear.MaintenanceCost = (currentHomeValue * ownershipCosts.MaintenancePercentage).RoundToTwoDecimalPlaces();
        }

        private void CalculateCommonFeeEachYear(Dictionary<ushort, OwnershipCostEachYear>
            ownershipCostPerYear,
            ushort year,
            decimal inflation)
        {
            var currentYear = ownershipCostPerYear[year];
            var commonFeePreviousYear = ownershipCostPerYear[--year].CommonFee;
            var feeIncrease = commonFeePreviousYear * inflation;
            currentYear.CommonFee = (feeIncrease + commonFeePreviousYear).RoundToTwoDecimalPlaces();
        }

        private void CalculateExcessUtilitiesEachYear(Dictionary<ushort, OwnershipCostEachYear>
          ownershipCostPerYear,
          ushort year,
          decimal inflation)
        {
            var currentYear = ownershipCostPerYear[year];
            var excessUtilities = ownershipCostPerYear[--year].ExcessUtilities;
            var utilityIncrease = excessUtilities * inflation;
            currentYear.ExcessUtilities = (utilityIncrease + excessUtilities).RoundToTwoDecimalPlaces();
        }
    }
}
