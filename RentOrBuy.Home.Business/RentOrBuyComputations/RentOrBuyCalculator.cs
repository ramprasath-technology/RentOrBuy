using RentOrBuy.Home.Business.HomeownershipComputations.HomeAppreciationComputation;
using RentOrBuy.Home.Business.HomeownershipComputations.HomeOwnershipComputation;
using RentOrBuy.Home.Business.HomeownershipComputations.TotalHomeOwnershipCostComputation;
using RentOrBuy.Home.Business.RentalComputations.RentalCostComputation;
using RentOrBuy.Home.Business.RentalComputations.TotalRentalCostComputation;
using RentOrBuy.Home.DataModel;
using RentOrBuy.Home.DataModel.CalculationResponse;
using RentOrBuy.Home.DataModel.OwnershipCost;
using RentOrBuy.Home.DataModel.RentCost;
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
        private readonly ITotalHomeOwnershipCostCalculator _totalHomeownershipCostCalculator;
        private readonly ITotalRentalCostCalculator _totalRentalCostCalculator;
        public RentOrBuyCalculator(IHomeOwnershipCostCalculator homeOwnershipCalculator,
            IHomeAppreciationCalculator homeAppreciationCalculator,
            IRentalCostCalculator rentalCostCalculator,
            ITotalHomeOwnershipCostCalculator totalHomeownershipCostCalculator,
            ITotalRentalCostCalculator totalRentalCostCalculator)
        {
            _homeAppreciationCalculator = homeAppreciationCalculator;
            _homeOwnershipCalculator = homeOwnershipCalculator;
            _rentalCostCalculator = rentalCostCalculator;
            _totalHomeownershipCostCalculator = totalHomeownershipCostCalculator;
            _totalRentalCostCalculator = totalRentalCostCalculator;
        }

        public async Task<Response> GetRentOrBuyDecision(UserInput input)
        {
            var homeAppreciation = _homeAppreciationCalculator.CalculateHomePriceForEachYear(
                input.OwnershipCosts.Price,
                input.PlannedLengthOfStay,
                input.OwnershipCosts.AnnualPriceGrowthRate);

            var homeOwnershipCostTask = Task.Run(() =>
            {
                return _homeOwnershipCalculator.CalculateHomeOwnershipCost(
                    input.OwnershipCosts,
                    input.EconomicCosts,
                    homeAppreciation);
            });

            var rentalCostTask = Task.Run(() =>
            {
                return _rentalCostCalculator.CalculateRentalCost(
                    input.RentCosts,
                    input.PlannedLengthOfStay);
            });

            var homeownershipCost = await homeOwnershipCostTask;
            var rentalCost = await rentalCostTask;

            var totalOwnershipCost = _totalHomeownershipCostCalculator.CalculateTotalOwnershipCost(
                homeownershipCost.Values.ToList(),
                input.OwnershipCosts);

            var totalRentalCost = _totalRentalCostCalculator.CalculateTotalRentalCost(
                rentalCost.Values.ToList());

            return new Response();
        }
    }
}
