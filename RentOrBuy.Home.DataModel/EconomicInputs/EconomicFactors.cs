using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel.EconomicInputs
{
    public record EconomicFactors
    {
        public decimal Inflation { get; set; }
        public decimal InvestmentReturn { get; set; }
    }
}
