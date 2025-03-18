using RentOrBuy.Home.DataModel.OwnershipCost;
using CommonExtensions.MathExtensions;
using RentOrBuy.Home.DataModel.EconomicInputs;

namespace RentOrBuy.Home.Business.HomeownershipCompuations
{
    public class HomeOwnershipCostCalculator : IHomeOwnershipCostCalculator
    {
        public Dictionary<ushort, OwnershipCostEachYear> CalculateHomeOwnershipCost(OwnershipCostFactors ownershipCosts,
            EconomicFactors economicFactors,
            Dictionary<byte, decimal> homeValueEachYear)
        {
            var costTracker = new Dictionary<ushort, OwnershipCostEachYear>();
            InitializeOwnershipCostTracker(costTracker, (byte)homeValueEachYear.Count);
            CalculateOwnershipCostForEachYear(ownershipCosts, economicFactors, costTracker, homeValueEachYear);
            return costTracker;
        }

        private void InitializeOwnershipCostTracker(Dictionary<ushort, OwnershipCostEachYear> tracker, 
            byte lengthOfStay)
        {
            for (byte i = 0; i < lengthOfStay; i++)
            {
                tracker[i] = new OwnershipCostEachYear();
            }
        }

        private void CalculateOwnershipCostForEachYear(OwnershipCostFactors ownershipCosts,
            EconomicFactors economicFactors,
            Dictionary<ushort, OwnershipCostEachYear> ownershipCostsPerYear,
            Dictionary<byte, decimal> homeValueEachYear)
        {
            CalculateCostsForYearZero(ownershipCosts, ownershipCostsPerYear);
            for (byte i = 1; i < ownershipCostsPerYear.Count; i++)
            {
                CalculatePropertyTaxEachYear(ownershipCostsPerYear, ownershipCosts, i, homeValueEachYear[i]);
                CalculateMaintenanceEachYear(ownershipCostsPerYear, ownershipCosts, i, homeValueEachYear[i]);
                CalculateHomeInsuranceEachYear(ownershipCostsPerYear, ownershipCosts, i, homeValueEachYear[i]);
                CalculateCommonFeeEachYear(ownershipCostsPerYear, i, economicFactors.Inflation);
                CalculateExcessUtilitiesEachYear(ownershipCostsPerYear, i, economicFactors.Inflation);
            }
        }

        private void CalculateCostsForYearZero(OwnershipCostFactors ownershipCosts,
            Dictionary<ushort, OwnershipCostEachYear> ownershipCostPerYear)
        {
            ownershipCostPerYear[0].CommonFee = ownershipCosts.MonthlyCommonFees * 12;
            ownershipCostPerYear[0].ExcessUtilities = ownershipCosts.MonthlyUtilities * 12;
            ownershipCostPerYear[0].MaintenanceCost = (ownershipCosts.Price * ownershipCosts.MaintenancePercentage).RoundToTwoDecimalPlaces();
            ownershipCostPerYear[0].HomeInsurance = (ownershipCosts.Price * ownershipCosts.HomeownerInsurancePercentage).RoundToTwoDecimalPlaces();
        }

        private void CalculatePropertyTaxEachYear(Dictionary<ushort, OwnershipCostEachYear>
            ownershipCostPerYear,
            OwnershipCostFactors ownershipCosts,
            byte year,
            decimal currentHomeValue)
        {
            var currentYear = ownershipCostPerYear[year];
            currentYear.PropertyTax = (currentHomeValue * ownershipCosts.PropertyTaxPercentage / 100).RoundToTwoDecimalPlaces();
        }

        private void CalculateHomeInsuranceEachYear(Dictionary<ushort, OwnershipCostEachYear>
            ownershipCostPerYear,
            OwnershipCostFactors ownershipCosts,
            byte year,
            decimal currentHomeValue)
        {
            var currentYear = ownershipCostPerYear[year];
            currentYear.HomeInsurance = (currentHomeValue * ownershipCosts.HomeownerInsurancePercentage / 100).RoundToTwoDecimalPlaces();
        }

        private void CalculateMaintenanceEachYear(Dictionary<ushort, OwnershipCostEachYear>
            ownershipCostPerYear,
            OwnershipCostFactors ownershipCosts,
            byte year,
            decimal currentHomeValue)
        {
            var currentYear = ownershipCostPerYear[year];
            currentYear.MaintenanceCost = (currentHomeValue * ownershipCosts.MaintenancePercentage / 100).RoundToTwoDecimalPlaces();
        }

        private void CalculateCommonFeeEachYear(Dictionary<ushort, OwnershipCostEachYear>
            ownershipCostPerYear,
            byte year,
            decimal inflation)
        {
            var currentYear = ownershipCostPerYear[year];
            var commonFeePreviousYear = ownershipCostPerYear[--year].CommonFee;
            var feeIncrease = commonFeePreviousYear * (inflation / 100);
            currentYear.CommonFee = (feeIncrease + commonFeePreviousYear).RoundToTwoDecimalPlaces();
        }

        private void CalculateExcessUtilitiesEachYear(Dictionary<ushort, OwnershipCostEachYear>
          ownershipCostPerYear,
          byte year,
          decimal inflation)
        {
            var currentYear = ownershipCostPerYear[year];
            var excessUtilities = ownershipCostPerYear[--year].ExcessUtilities;
            var utilityIncrease = excessUtilities * (inflation / 100);
            currentYear.ExcessUtilities = (utilityIncrease + excessUtilities).RoundToTwoDecimalPlaces();
        }
    }
}
