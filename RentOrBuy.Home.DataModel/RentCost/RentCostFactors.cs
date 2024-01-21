using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel.RentCost
{
    public record RentCostFactors
    {
        public decimal MonthlyRent { get; set; }
        public decimal AnnualRentGrowthRate { get; set; }
        public decimal RentersInsurance { get; set; }
    }
}
