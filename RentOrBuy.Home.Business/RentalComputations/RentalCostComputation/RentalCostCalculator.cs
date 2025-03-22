using CommonExtensions.MathExtensions;
using RentOrBuy.Home.DataModel.RentCost;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.RentalComputations.RentalCostComputation
{
    public class RentalCostCalculator : IRentalCostCalculator
    {
        public Dictionary<byte, RentCostEachYear> CalculateRentalCost(RentCostFactors rentFactor,
            byte lengthOfStay)
        {
            var rentalCost = new Dictionary<byte, RentCostEachYear>();
            InitializeRentCost(rentalCost, lengthOfStay);
            CalculateRentForDurationOfStay(rentalCost, rentFactor);
            CalculateRentalInsuranceForDurationOfStay(rentalCost, rentFactor.RentersInsuranceInPercentage, lengthOfStay);
            return rentalCost;
        }

        private void InitializeRentCost(Dictionary<byte, RentCostEachYear> rentalCost,
            byte lengthOfStay)
        {
            for (byte i = 0; i < lengthOfStay; i++)
            {
                rentalCost[i] = new RentCostEachYear();
            }
        }

        private void CalculateRentForDurationOfStay(Dictionary<byte, RentCostEachYear> rentalCost,
            RentCostFactors rentFactor)
        {
            rentalCost[0].Rent = rentFactor.YearlyRent;

            for (byte i = 1; i < rentalCost.Count; i++)
            {
                var previousYearRent = rentalCost[(byte)(i - 1)].Rent;
                var increaseInRent = previousYearRent * rentFactor.AnnualRentGrowthRate / 100;
                rentalCost[i].Rent = (previousYearRent + increaseInRent).RoundToTwoDecimalPlaces();
            }
        }

        private void CalculateRentalInsuranceForDurationOfStay(Dictionary<byte, RentCostEachYear> rentalCost,
            decimal rentalInsuranceAsPercentageOfRent,
            byte lengthOfStay)
        {
            for (byte i = 0; i < rentalCost.Count; ++i)
            {
                var rentThisYear = rentalCost[i].Rent;
                var rentalInsurance = rentThisYear * rentalInsuranceAsPercentageOfRent / 100;
                rentalCost[i].RentalInsurance = rentalInsurance.RoundToTwoDecimalPlaces();
            }
        }


    }
}
