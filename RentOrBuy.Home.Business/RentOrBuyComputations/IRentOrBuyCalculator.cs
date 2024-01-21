using RentOrBuy.Home.DataModel;
using RentOrBuy.Home.DataModel.CalculationResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.Business.RentOrBuyComputations
{
    public interface IRentOrBuyCalculator
    {
        Task<Response> GetRentOrBuyDecision(UserInput input);
    }
}
