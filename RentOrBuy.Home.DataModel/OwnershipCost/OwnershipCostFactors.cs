using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel.OwnershipCost
{
    public record OwnershipCostFactors
    {
        public uint Price { get; init; }
        [Description("Projected annual home price growth as percentage of home value")]
        public decimal AnnualPriceGrowthRate { get; set; }

        #region Mortgage Details
        public decimal MortgageRate { get; set; }
        public decimal DownPaymentPercentage { get; set; }
        public byte LengthOfMortgage { get; set; }
        [Description("Closing cost when buying a house as percentage of purchase price")]
        #endregion

        #region One Time Costs
        public decimal ClosingCostWhenBuying { get; set; }
        [Description("Closing cost when selling a house as percentage of selling price")]
        public decimal ClosingCostWhenSelling { get; set; }
        [Description("Annual maintenance fee as percentage of home value")]
        #endregion

        #region Ongoing costs
        public decimal MaintenancePercentage { get; set; }
        [Description("Annual home owner insurance as percentage of home value")]
        public decimal HomeownerInsurancePercentage { get; set; }
        [Description("Monthly utility costs more than what you pay when you rent")]
        public uint MonthlyUtilities { get; set; }
        public uint MonthlyCommonFees { get; set; }
        public decimal PropertyTaxPercentage { get; set; }
        #endregion

    }
}
