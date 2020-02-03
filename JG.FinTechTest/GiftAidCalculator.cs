using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest
{
    public class GiftAidCalculator
    {
        private decimal Multiplier { get;}

        public GiftAidCalculator(decimal taxRate)
        {
            if (taxRate > 100 || taxRate < 0)
            {
                throw new ArgumentException("Tax Rate percentage value should be between 0 and 100");
            }
            Multiplier = taxRate / (100 - taxRate);
        }

        public decimal CalculateGiftAid(decimal donationAmount)
        {
            return donationAmount * Multiplier;
        }
    }
}
