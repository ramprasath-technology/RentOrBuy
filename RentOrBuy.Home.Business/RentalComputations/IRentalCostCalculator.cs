using RentOrBuy.Home.DataModel.RentCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.RentalComputations
{
    public interface IRentalCostCalculator
    {
        Dictionary<byte, RentCostEachYear> CalculateRentalCost(RentCostFactors rentFactor,
            byte lengthOfStay);
    }
}
