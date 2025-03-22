using RentOrBuy.Home.DataModel.RentCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.RentalComputations.TotalRentalCostComputation
{
    public interface ITotalRentalCostCalculator
    {
        TotalRentalCost CalculateTotalRentalCost(List<RentCostEachYear> rentCostEachYear);
    }
}
