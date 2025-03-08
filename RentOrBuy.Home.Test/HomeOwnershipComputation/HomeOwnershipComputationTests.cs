using RentOrBuy.Home.Business.HomeownershipCompuations;
using RentOrBuy.Home.DataModel.EconomicCost;
using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Test.HomeOwnershipComputation
{
    public class HomeOwnershipComputationTests
    {
        private HomeOwnershipCalculator _owneshipCalculator;
        public HomeOwnershipComputationTests() 
        {
            _owneshipCalculator = new HomeOwnershipCalculator();
        }

        [Fact]
        public void HomeOwnershipCalculator_NoException()
        {
            var ownershipCosts = new OwnershipCostFactors()
            {
                AnnualPriceGrowthRate = 1,
                ClosingCostWhenBuying = 2,
                ClosingCostWhenSelling = 5,
                DownPaymentPercentage = 20,
                HomeownerInsurancePercentage = 0.5m,
                LengthOfMortgage = 30,
                MaintenancePercentage = 1,
                MonthlyCommonFees = 100,
                MonthlyUtilities = 100,
                MortgageRate = 5,
                PlannedLengthOfStay = 10,
                Price = 500000,
                PropertyTaxPercentage = 1.5m
            };
            var economicFactors = new EconomicCostFactors()
            {
                Inflation = 2,
                InvestmentReturn = 8
            };
            var calulatorObject = _owneshipCalculator.CalculateHomeOwnershipCost(ownershipCosts,
                economicFactors);

            Assert.NotNull(calulatorObject);
        }
    }
}
