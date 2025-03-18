using RentOrBuy.Home.DataModel.EconomicInputs;
using RentOrBuy.Home.DataModel.OwnershipCost;
using RentOrBuy.Home.DataModel.RentCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel
{
    public record UserInput
    {
        public OwnershipCostFactors OwnershipCosts { get; set; } = new OwnershipCostFactors();
        public RentCostFactors RentCosts { get; set; } = new RentCostFactors();
        public EconomicFactors EconomicCosts { get; set; } = new EconomicFactors();
        public byte PlannedLengthOfStay { get; set; }
    }
}
