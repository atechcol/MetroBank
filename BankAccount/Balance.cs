using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BalanceModel
    {
        public Valuta Valuta { get; set; }

        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                _balance = value;
            }
        }

        public BalanceModel(Valuta valuta, decimal balance)
        {
            this.Balance = balance;
            this.Valuta = valuta;
        }

        public BalanceModel() : this(new Valuta(), 0.0M) { }
    }
}
