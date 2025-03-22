using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.HomeownershipComputations.TotalHomeOwnershipCostComputation
{
    public interface ITotalHomeOwnershipCostCalculator
    {
        TotalOwnershipCost CalculateTotalOwnershipCost(List<OwnershipCostEachYear> ownershipCostEachYear,
            OwnershipCostFactors ownershipCostFactors);
    }
}
