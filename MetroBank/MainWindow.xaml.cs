using MahApps.Metro.Controls;

using MetroBank;
using System;
using System.Threading.Tasks;
using System.ComponentModel;

using BankAccount;

namespace MetroBank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MetroBank.ViewModels.OverviewViewModel AccountViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            AccountViewModel = new ViewModels.OverviewViewModel();
            AccountViewModel.Account = new DebitBankAccount();
            this.DataContext = AccountViewModel;
        }

        private void DepositButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AccountViewModel.Deposit();
            DepositFlyout.IsOpen = true;
            DepositBox.Text = "";
        }

        private void WithdrawButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            bool successful = AccountViewModel.Withdraw();
            if (successful)
            {
                WithdrawFlyout.IsOpen = true;
            }
            else
            {
                WithdrawBadFlyout.IsOpen = true;
            }
            
            WithdrawBox.Text = "";
        }

        private void DepositBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            decimal result;
            bool parsed = decimal.TryParse(DepositBox.Text, out result);
            if (parsed)
            {
                AccountViewModel.DepositAmount = result;
            }
        }

        private void WithdrawBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            decimal result;
            bool parsed = decimal.TryParse(WithdrawBox.Text, out result);
            if (parsed)
            {
                AccountViewModel.WithdrawAmount = result;
            } 
        }
    }
}
