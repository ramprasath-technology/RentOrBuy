using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel.OwnershipCost
{
    public class OwnershipCostEachYear
    {
        public decimal PropertyTax { get; set; }
        public decimal HomeInsurance { get; set; }
        public decimal MaintenanceCost { get; set; }
        public decimal CommonFee { get; set; }
        public decimal ExcessUtilities { get; set; }
    }
}
