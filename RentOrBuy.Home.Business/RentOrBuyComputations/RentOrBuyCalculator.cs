using RentOrBuy.Home.Business.HomeownershipCompuations;
using RentOrBuy.Home.Business.HomeownershipComputations;
using RentOrBuy.Home.Business.RentalComputations;
using RentOrBuy.Home.DataModel;
using RentOrBuy.Home.DataModel.CalculationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.RentOrBuyComputations
{
    public class RentOrBuyCalculator : IRentOrBuyCalculator
    { 

        private readonly IHomeAppreciationCalculator _homeAppreciationCalculator;
        private readonly IHomeOwnershipCostCalculator _homeOwnershipCalculator;
        private readonly IRentalCostCalculator _rentalCostCalculator;
        public RentOrBuyCalculator(IHomeOwnershipCostCalculator homeOwnershipCalculator,
            IHomeAppreciationCalculator homeAppreciationCalculator,
            IRentalCostCalculator rentalCostCalculator)
        {
            _homeAppreciationCalculator = homeAppreciationCalculator;
            _homeOwnershipCalculator = homeOwnershipCalculator;
            _rentalCostCalculator = rentalCostCalculator;
        }

        public async Task<Response> GetRentOrBuyDecision(UserInput input)
        {
            var homeAppreciation = _homeAppreciationCalculator.CalculateHomePriceForEachYear(
                input.OwnershipCosts.Price, 
                input.PlannedLengthOfStay,
                input.OwnershipCosts.AnnualPriceGrowthRate);

            var homeOwnershipCost = _homeOwnershipCalculator.CalculateHomeOwnershipCost(
                input.OwnershipCosts,
                input.EconomicCosts,
                homeAppreciation);

            var rentalCost = _rentalCostCalculator.CalculateRentalCost(
                input.RentCosts,
                input.PlannedLengthOfStay
                );

            return new Response();
        }
    }
}
