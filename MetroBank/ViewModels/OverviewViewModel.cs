using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using PropertyChanged;

using BankAccount;

namespace MetroBank.ViewModels
{
    public class OverviewViewModel : BaseViewModel
    {
        public Account Account { get; set; }

        private decimal _balance;
        public decimal Balance
        {
            get 
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        }

        public string BalanceString
        {
            get
            {
                string currency = Account.BalanceData.Valuta.Kind.ToString();
                return Balance.ToString() + " " + currency;
            }
        }

        public decimal DepositAmount { get; set; }
        public decimal WithdrawAmount { get; set; }

        public OverviewViewModel()
        {
            this.Balance = 0.0M;
            this.DepositAmount = 0.0M;
            this.WithdrawAmount = 0.0M;
        }

        public bool Deposit()
        {
            Account.Desposit(this.DepositAmount);
            this.Balance = Account.BalanceData.Balance;
            return true;
        }

        public bool Withdraw()
        {
            decimal amount = Account.Withdraw(this.WithdrawAmount);
            this.Balance = Account.BalanceData.Balance;

            if (amount == -1.0M)
            {
                return false;
            }
            return true;
        }
    }
}
