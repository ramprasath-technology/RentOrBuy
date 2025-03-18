using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel.RentCost
{
    public class TotalRentalCost
    {
        public decimal TotalRent { get; set; }
        public decimal TotalRentalInsurance { get; set; }
        public decimal TotalCost => TotalRent + TotalRentalInsurance;
    }
}
