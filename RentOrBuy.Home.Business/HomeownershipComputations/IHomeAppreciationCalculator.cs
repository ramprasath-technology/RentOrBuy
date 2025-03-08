using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.HomeownershipComputations
{
    public interface IHomeAppreciationCalculator
    {
        Dictionary<byte, decimal> CalculateHomePriceForEachYear(decimal purchasePrice,
            byte lengthOfStay,
            decimal homeAppreciationPercentage);
    }
}
