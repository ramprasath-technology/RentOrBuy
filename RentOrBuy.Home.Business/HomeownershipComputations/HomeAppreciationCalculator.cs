using CommonExtensions.MathExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.HomeownershipComputations
{
    public class HomeAppreciationCalculator : IHomeAppreciationCalculator
    {
        public Dictionary<byte, decimal> CalculateHomePriceForEachYear(decimal purchasePrice,
            byte lengthOfStay,
            decimal homeAppreciationPercentage)
        {
            var yearHomePriceMap = new Dictionary<byte, decimal>();
            if (lengthOfStay == 0)
                return yearHomePriceMap;
            yearHomePriceMap[0] = purchasePrice;

            for (byte i = 1; i < lengthOfStay; i++)
            {
                var previousYearPrice = yearHomePriceMap[(byte)(i - 1)];
                var currentYearAppreciaion = previousYearPrice * homeAppreciationPercentage / 100;
                yearHomePriceMap[i] = (previousYearPrice + currentYearAppreciaion).RoundToTwoDecimalPlaces();
            }

            return yearHomePriceMap;
        }


    }
}
