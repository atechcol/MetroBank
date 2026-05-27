using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public enum ValutaKind
    {
        EUR,
        DKK,
        SEK,
    }

    public class Valuta
    {
        public ValutaKind Kind { get; set; }
        /// <summary>
        /// Conversion rate between the euro and this valuta.
        /// </summary>
        public decimal EuroConversionRate { get; set; }

        public Valuta(ValutaKind kind, decimal conversionRate)
        {
            this.Kind = kind;
            this.EuroConversionRate = conversionRate;
        }

        public Valuta() : this(ValutaKind.EUR, 1.0M) { }

        /// <summary>
        /// Converts an amount of money of this valuta to another valuta
        /// </summary>
        /// <param name="otherValuta"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal ConvertTo(Valuta otherValuta, decimal amount)
        {
            decimal ratio = otherValuta.EuroConversionRate / this.EuroConversionRate;
            return ratio * amount;
        }
    }
}
