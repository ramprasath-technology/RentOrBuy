using Moq;
using RentOrBuy.Home.Business.RentalComputations.TotalRentalCostComputation;
using RentOrBuy.Home.DataModel.RentCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Test.RentalComputation
{
    public class TotalRentalCostCalculatorTest
    {
        private TotalRentalCostCalculator _totalRentalCostCalculator;

        public TotalRentalCostCalculatorTest()
        {
            _totalRentalCostCalculator = new TotalRentalCostCalculator();
        }

        [Fact]
        public void TotalRentalCostCalculator_NoExceptionTest()
        {
            var rentCostEachYear = new List<RentCostEachYear>
            {
                new RentCostEachYear()
                {
                    Rent = 5000,
                    RentalInsurance = 100
                },
                new RentCostEachYear()
                {
                    Rent = 5050,
                    RentalInsurance = 150
                }
            };
            TotalRentalCost? totalRentalCost = _totalRentalCostCalculator.CalculateTotalRentalCost(rentCostEachYear);
            Assert.NotNull(totalRentalCost);
            Assert.True(totalRentalCost.TotalRent == (5000 + 5050));
            Assert.True(totalRentalCost.TotalRentalInsurance == (100 + 150));
            Assert.True(totalRentalCost.TotalCost == (5000 + 5050 + 100 + 150));
        }
    }
}
