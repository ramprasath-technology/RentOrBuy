using CommonExtensions.MathExtensions;
using Moq;
using RentOrBuy.Home.Business.RentalComputations.RentalCostComputation;
using RentOrBuy.Home.DataModel.RentCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Test.RentalComputation
{
    public class RentalCostCalculationTest
    {
        private readonly Mock<RentalCostCalculator> _rentalCostCalculator;

        public RentalCostCalculationTest()
        {
            _rentalCostCalculator = new Mock<RentalCostCalculator>();
        }

        [Fact]
        public void RentalCostCalculator_NoExceptionsTest()
        {
            var rentalFactor = new RentCostFactors()
            {
                AnnualRentGrowthRate = 3,
                YearlyRent = 2000,
                RentersInsuranceInPercentage = 2
                
            };
            byte lengthOfStay = 5;
            var rentalCost = _rentalCostCalculator.Object.CalculateRentalCost(rentalFactor, lengthOfStay);
            Assert.True(rentalCost.Count == lengthOfStay);
        }

        [Fact]
        public void RentalCostCalculator_RentsTest()
        {
            for (var i = 0; i < 50; i++)
            {
                var randomGenerator = new Random();
                var rentalFactor = new RentCostFactors()
                {
                    AnnualRentGrowthRate = (randomGenerator.Next(1, 10) + (decimal)randomGenerator.NextDouble()).RoundToTwoDecimalPlaces(),
                    YearlyRent = randomGenerator.Next(500, 10000),
                    RentersInsuranceInPercentage = Convert.ToDecimal(randomGenerator.NextDouble()) + randomGenerator.Next(0, 5),

                };
                byte lengthOfStay = (byte)randomGenerator.Next(2, 25);
                var rentalCost = _rentalCostCalculator.Object.CalculateRentalCost(rentalFactor, lengthOfStay);
                var lastYear = (byte)(rentalCost.Count - 1);
                var penUltimateYear = (byte)(lastYear - 1);
                var rentIncrease = rentalCost[lastYear].Rent - rentalCost[penUltimateYear].Rent;
                var rentIncreasePercentage = ((rentIncrease / rentalCost[penUltimateYear].Rent) * 100).RoundToTwoDecimalPlaces();
                Assert.True(rentIncreasePercentage == rentalFactor.AnnualRentGrowthRate);
            }
        }

        [Fact]
        public void RentalCostCalculator_InsuranceTest()
        {
            for (var i = 0; i < 50; i++)
            {
                var randomGenerator = new Random();
                var rentalFactor = new RentCostFactors()
                {
                    AnnualRentGrowthRate = (randomGenerator.Next(1, 10) + (decimal)randomGenerator.NextDouble()).RoundToTwoDecimalPlaces(),
                    YearlyRent = randomGenerator.Next(500, 10000),
                    RentersInsuranceInPercentage = (Convert.ToDecimal(randomGenerator.NextDouble()) + randomGenerator.Next(0, 5)).RoundToTwoDecimalPlaces(),

                };
                byte lengthOfStay = (byte)randomGenerator.Next(2, 25);
                var rentalCost = _rentalCostCalculator.Object.CalculateRentalCost(rentalFactor, lengthOfStay);
                var rentalInsuranceForFirstYear = (rentalFactor.YearlyRent * rentalFactor.RentersInsuranceInPercentage / 100).RoundToTwoDecimalPlaces();
                var lastYear = (byte)(rentalCost.Count - 1);
                var rentForLastYear = rentalCost[lastYear].Rent;
                var rentalInsuranceForLastYear = (rentForLastYear * rentalFactor.RentersInsuranceInPercentage / 100).RoundToTwoDecimalPlaces();
                Assert.True(rentalCost[0].RentalInsurance == rentalInsuranceForFirstYear);
                Assert.True(rentalCost[lastYear].RentalInsurance == rentalInsuranceForLastYear);
            }
        }
    }
}
