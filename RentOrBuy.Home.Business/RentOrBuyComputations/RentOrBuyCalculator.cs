using RentOrBuy.Home.Business.HomeownershipCompuations;
using RentOrBuy.Home.Business.HomeownershipComputations;
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
        public RentOrBuyCalculator(IHomeOwnershipCostCalculator homeOwnershipCalculator,
            IHomeAppreciationCalculator homeAppreciationCalculator)
        {
            _homeAppreciationCalculator = homeAppreciationCalculator;
            _homeOwnershipCalculator = homeOwnershipCalculator;  
        }

        public async Task<Response> GetRentOrBuyDecision(UserInput input)
        {
            var homeAppreciation = _homeAppreciationCalculator.CalculateHomePriceForEachYear(
                input.OwnershipCosts.Price, 
                input.OwnershipCosts.PlannedLengthOfStay,
                input.OwnershipCosts.AnnualPriceGrowthRate);

            


            var ownershipCostsTask = Task.Run(() =>
            {
                return _homeOwnershipCalculator.CalculateHomeOwnershipCost(input.OwnershipCosts, input.EconomicCosts);
            });
            
            //TODO: Rental costs task

            var ownershipCosts = await ownershipCostsTask;

            //TODO: Compare opportunity cost

            //TODO: Construct the response

            return new Response();
        }
    }
}
