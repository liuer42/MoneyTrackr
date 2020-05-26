using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoneyTycoon.Models;
using MoneyTycoon.ViewModels;

namespace MoneyTycoon.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class TransactionDetailPage : ContentPage
    {
        TransactionDetailViewModel viewModel;

        public TransactionDetailPage(TransactionDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public TransactionDetailPage()
        {
            InitializeComponent();

            var tx = new Transaction
            {
                Value = 0,
                Description = ""                
            };

            viewModel = new TransactionDetailViewModel(tx);
            BindingContext = viewModel;
        }
    }
}