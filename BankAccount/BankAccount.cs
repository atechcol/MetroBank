using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class Account
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (value >= 1)
                {
                    _id = value;
                }
            }
        }

        #region Name fields
        private string _firstName;
        public string FirstName 
        {
            get { return _firstName;  } 
            set
            {
                if (value.Length == 0)
                {
                    return;
                }
                _firstName = value;
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value.Length == 0)
                {
                    return;
                }
                _lastName = value;
            }
        }

        public string FullName { get { return string.Format("%s %s", FirstName, LastName); } }
        #endregion Name

        public BalanceModel BalanceData { get; set; }

        #region Constructors
        public Account(string firstName, string lastName, Valuta valuta, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            BalanceData = new BalanceModel(valuta, balance);
        }

        public Account() : this("John", "Doe", new Valuta(), 0.0M) { }
        #endregion

        /// <summary>
        /// Withdraws money from account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>The actual amount of money withdrawn.</returns>
        public abstract decimal Withdraw(decimal amount);
        /// <summary>
        /// Deposits money to account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>The actual amount of money deposited.</returns>
        public abstract decimal Desposit(decimal amount);

        public decimal Transfer(decimal amount, Account account)
        {
            decimal convertedAmount = BalanceData.Valuta.ConvertTo(account.BalanceData.Valuta, amount);
            decimal actualTransferred = account.Desposit(convertedAmount);

            decimal convertedTransferred = account.BalanceData.Valuta.ConvertTo(BalanceData.Valuta, actualTransferred);
            this.Withdraw(convertedTransferred);

            return convertedTransferred;
        }
    }

    public class DebitBankAccount : Account
    {
        public override decimal Withdraw(decimal amount)
        {
            if (amount > BalanceData.Balance)
            {
                return -1.0M;
            }

            BalanceData.Balance -= amount;
            return amount;
        }

        public override decimal Desposit(decimal amount)
        {
            BalanceData.Balance += amount;
            return amount;
        }
    }

    public class CreditBankAccount : Account
    {

        public override decimal Withdraw(decimal amount)
        {
            BalanceData.Balance -= amount;
            return amount;
        }

        public override decimal Desposit(decimal amount)
        {
            BalanceData.Balance += amount;
            return amount;
        }
    }
}
