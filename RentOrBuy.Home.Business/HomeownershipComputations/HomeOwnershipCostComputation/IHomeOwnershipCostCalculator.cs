﻿using RentOrBuy.Home.DataModel.EconomicInputs;
using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.HomeownershipComputations.HomeOwnershipComputation
{
    public interface IHomeOwnershipCostCalculator
    {
        /// <summary>
        /// Calculate ownership cost for each year of planned length of stay
        /// </summary>
        /// <param name="ownershipCostFactors"></param>
        /// <returns>Key is year, value is cost. Key ranges from 0 to planned length of stay - 1</returns>
        Dictionary<byte, OwnershipCostEachYear> CalculateHomeOwnershipCost(OwnershipCostFactors ownershipCosts,
            EconomicFactors economicFactors,
            Dictionary<byte, decimal> homeValueEachYear);
    }
}
