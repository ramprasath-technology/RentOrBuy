using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonExtensions.MathExtensions
{
    public static class DecimalExtensions
    {
        public static decimal RoundToTwoDecimalPlaces(this decimal number)
        {
            return Math.Round(number, 2, MidpointRounding.AwayFromZero);
        }
    }
}
