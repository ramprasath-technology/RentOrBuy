using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel.OwnershipCost
{
    public class TotalOwnershipCost
    {
        public decimal TotalMortgagePayment { get; set; }
        public decimal DownPayment { get; set; }
        public decimal TotalOneTimeCost { get; set; }
        public decimal TotalInsurancePremiums { get; set; }
        public decimal TotalPropertyTax { get; set; }
        public decimal TotalExcessUtilitiesCost { get; set; }
        public decimal TotalMaintenanceCost { get; set; }
        public decimal TotalCost => TotalMortgagePayment + DownPayment + TotalOneTimeCost + TotalInsurancePremiums + TotalPropertyTax + TotalExcessUtilitiesCost + TotalMaintenanceCost;
    }
}
