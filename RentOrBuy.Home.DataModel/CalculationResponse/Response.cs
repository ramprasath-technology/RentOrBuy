using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentOrBuy.Home.DataModel.CalculationResponse
{
    public class Response
    {
        public Action Action { get; set; }
        public decimal TotalSaving { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
    }

    public enum Action
    {
        [Description("Own")]
        Own = 0,
        [Description("Rent")]
        Rent
    }
}
