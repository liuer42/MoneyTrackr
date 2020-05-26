using MoneyTycoon.Models;
using MoneyTycoon.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyTycoon.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneyPage : ContentPage
    {
        MoneyViewModel viewModel;       

        public MoneyPage()
        {
            InitializeComponent();
            
            BindingContext = viewModel = new MoneyViewModel();
        }

        async void AddTx_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTransactionPage
                {
                    BindingContext = new Transaction(),
                    IsExpense = false
                }
            ));
        }

        async void NegTx_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTransactionPage
                {
                    BindingContext = new Transaction(),
                    IsExpense = true
                } 
            ));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var runningTotal = 0M;

            var txs = await App.Database.GetTransactions();
            foreach (var t in txs)
            {
                runningTotal += t.Value;
            }

            total.Text = (runningTotal > 0 ? "" : "-") + String.Format("{0:C}", runningTotal);
        }
    }
}