using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoneyTycoon.Models;
using MoneyTycoon.Views;
using MoneyTycoon.ViewModels;

namespace MoneyTycoon.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TransactionsPage : ContentPage
    {
        TransactionsViewModel viewModel;

        public TransactionsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new TransactionsViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var tx = (Transaction)layout.BindingContext;
            await Navigation.PushAsync(new TransactionDetailPage(new TransactionDetailViewModel(tx)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewTransactionPage()));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await viewModel.ExecuteLoadItemsCommand();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TransactionDetailPage
                {
                    BindingContext = e.SelectedItem as Transaction
                });
            }
        }
    }
}