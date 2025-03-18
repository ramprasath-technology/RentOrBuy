using RentOrBuy.Home.Business.HomeownershipComputations;
using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Test.HomeOwnershipComputation
{
    public class TotalHomeOwnershipCalculatorTest
    {
        private TotalHomeownershipCostCalculator _totalHomeownershipCostCalculator;
        public TotalHomeOwnershipCalculatorTest() 
        { 
            _totalHomeownershipCostCalculator = new TotalHomeownershipCostCalculator();
        }

        [Fact]
        public void TotalHomeOwnershipCostCalculator_NoExceptionTest()
        {
            var homeownershipCostForEachYear = new List<OwnershipCostEachYear>()
            {
                new OwnershipCostEachYear()
                {
                    CommonFee = 500,
                    ExcessUtilities = 1000.50m,
                    HomeInsurance = 5000.75m,
                    MaintenanceCost = 12000,
                    PropertyTax = 10000
                }
            };

            var totalOwnershipCost = _totalHomeownershipCostCalculator.CalculateTotalOwnershipCost(homeownershipCostForEachYear,
                new OwnershipCostFactors());
            
            Assert.NotNull(totalOwnershipCost);
        }

    }
}
