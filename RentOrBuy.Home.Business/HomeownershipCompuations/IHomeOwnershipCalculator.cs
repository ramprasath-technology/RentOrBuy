using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.HomeownershipCompuations
{
    public interface IHomeOwnershipCalculator
    {
        /// <summary>
        /// Calculate ownership cost for each year of planned length of stay
        /// </summary>
        /// <param name="ownershipCostFactors"></param>
        /// <returns>Key is year, value is cost. Key ranges from 0 to planned length of stay</returns>
        public Dictionary<ushort, decimal> CalculateHomeOwnershipCost(OwnershipCostFactors ownershipCostFactors);
    }
}
