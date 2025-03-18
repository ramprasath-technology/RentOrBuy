using RentOrBuy.Home.Business.HomeownershipCompuations;
using RentOrBuy.Home.DataModel.EconomicInputs;
using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Test.HomeOwnershipComputation
{
    public class HomeOwnershipCalculationTest
    {
        private HomeOwnershipCostCalculator _owneshipCalculator;
        public HomeOwnershipCalculationTest() 
        {
            _owneshipCalculator = new HomeOwnershipCostCalculator();
        }

        [Fact]
        public void HomeOwnershipCalculator_NoExceptionTest()
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
                Price = 500000,
                PropertyTaxPercentage = 1.5m
            };
            var economicFactors = new EconomicFactors()
            {
                Inflation = 2,
                InvestmentReturn = 8
            };

            var homeValueEachYear = new Dictionary<byte, decimal>();
            homeValueEachYear[0] = 500000;
            homeValueEachYear[1] = 505000;
            var calulatorObject = _owneshipCalculator.CalculateHomeOwnershipCost(ownershipCosts,
                economicFactors,
                homeValueEachYear);

            Assert.NotNull(calulatorObject);
        }
    }
}
