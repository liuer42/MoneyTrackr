using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MoneyTycoon.Models;
using MoneyTycoon.Views;

namespace MoneyTycoon.ViewModels
{
    public class TransactionsViewModel : BaseViewModel
    {

        public ObservableCollection<Transaction> Transactions { get; set; }
        public Command LoadItemsCommand { get; set; }

        public TransactionsViewModel()
        {
            Title = "Transaction History";
            Transactions = new ObservableCollection<Transaction>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Transactions.Clear();
                var tx = await App.Database.GetTransactions();
                tx.Reverse();
                foreach (var t in tx)
                {
                    Transactions.Add(t);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}