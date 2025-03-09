using CommonExtensions.MathExtensions;
using RentOrBuy.Home.Business.HomeownershipComputations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Test.HomeOwnershipComputation
{
    public class HomeAppreciationCalculatorTest
    {
        private HomeAppreciationCalculator _homeAppreciationCalculator;
        private decimal _medianHomePrice = 500000;

        public HomeAppreciationCalculatorTest()
        {
            _homeAppreciationCalculator = new HomeAppreciationCalculator();
        }

        [Fact]
        public void HomeAppreciationCalculator_NoExceptionTest()
        {
            var response = _homeAppreciationCalculator.CalculateHomePriceForEachYear(_medianHomePrice, 10, 3);
            Assert.NotNull(response);
        }

        [Fact]
        public void HomeAppreciationCalculator_SizeOfObjectTest()
        {
            var randomNumber = new Random();
            for (var i = 0; i < 10; i++)
            {    
                var lengthOfStay = randomNumber.Next(0, 255);
                var response = _homeAppreciationCalculator.CalculateHomePriceForEachYear(_medianHomePrice, (byte)lengthOfStay, 3);
                Assert.Equal(response.Count, lengthOfStay);
            }    
        }

        [Fact]
        public void HomeAppreciationCalculator_AppreciationValueTest()
        {
            var randomNumber = new Random();
            var tries = 100;

            for (int current = 0; current < tries; current++)
            {
                var annualAppreciationPercentage = randomNumber.Next(0, 10);
                var lengthOfStay = randomNumber.Next(0, 100);
                var response = _homeAppreciationCalculator.CalculateHomePriceForEachYear(_medianHomePrice, (byte)lengthOfStay, annualAppreciationPercentage);

                for (byte i = 1; i < lengthOfStay; i++)
                {
                    var differenceBetweenHomeValueInSubsequentYears = response[i] - response[(byte)(i - 1)];
                    var appreciationPercentage = (differenceBetweenHomeValueInSubsequentYears / response[(byte)(i - 1)]).RoundToTwoDecimalPlaces();
                    Assert.Equal((int)(appreciationPercentage * 100), (int)annualAppreciationPercentage);
                }
            }
        }
    }
}
