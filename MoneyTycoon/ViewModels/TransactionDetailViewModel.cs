using System;

using MoneyTycoon.Models;

namespace MoneyTycoon.ViewModels
{
    public class TransactionDetailViewModel : BaseViewModel
    {
        public Transaction Transaction { get; set; }
        public TransactionDetailViewModel(Transaction tx = null)
        {
            Title = tx?.Description;
            Transaction = tx;
        }
    }
}
