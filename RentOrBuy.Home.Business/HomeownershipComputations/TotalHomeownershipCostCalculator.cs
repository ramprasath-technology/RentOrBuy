using CommonExtensions.MathExtensions;
using RentOrBuy.Home.DataModel.OwnershipCost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.HomeownershipComputations
{
    public class TotalHomeownershipCostCalculator : ITotalHomeOwnershipCostCalculator
    {
        public TotalOwnershipCost CalculateTotalOwnershipCost(List<OwnershipCostEachYear> ownershipCostEachYear,
            OwnershipCostFactors ownershipCostFactors)
        {
            var totalOwnershipCost = new TotalOwnershipCost();
            foreach (var ownershipCostForCurrentYear in ownershipCostEachYear)
            {
                totalOwnershipCost.TotalMaintenanceCost += ownershipCostForCurrentYear.MaintenanceCost;
                totalOwnershipCost.TotalExcessUtilitiesCost += ownershipCostForCurrentYear.ExcessUtilities;
                totalOwnershipCost.TotalInsurancePremiums += ownershipCostForCurrentYear.HomeInsurance;
                totalOwnershipCost.TotalPropertyTax += ownershipCostForCurrentYear.PropertyTax;
            }
            totalOwnershipCost.TotalOneTimeCost = ownershipCostFactors.ClosingCostWhenBuying + ownershipCostFactors.ClosingCostWhenSelling;

            return totalOwnershipCost;
        }
    }
}
