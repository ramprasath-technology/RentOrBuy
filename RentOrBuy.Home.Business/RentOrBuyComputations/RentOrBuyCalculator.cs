using RentOrBuy.Home.Business.HomeownershipCompuations;
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
        private readonly IHomeOwnershipCalculator _homeOwnershipCalculator;
        public RentOrBuyCalculator(IHomeOwnershipCalculator homeOwnershipCalculator)
        {
            _homeOwnershipCalculator = homeOwnershipCalculator;
        }

        public async Task<Response> GetRentOrBuyDecision(UserInput input)
        {
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
