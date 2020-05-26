using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoneyTycoon.Models;

namespace MoneyTycoon.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewTransactionPage : ContentPage
    {
        public Transaction Transaction { get; set; }
        public bool IsExpense { get; set; }

        public NewTransactionPage()
        {
            InitializeComponent();

            Transaction = new Transaction
            {
                Value = 0,
                Description = "test"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var tx = (Transaction)BindingContext;
            if (IsExpense)
            {
                tx.Value = tx.Value * -1;
            }
            tx.Date = DateTime.UtcNow;
            await App.Database.AddBalanceTransaction(tx);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}