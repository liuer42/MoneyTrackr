using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyTycoon.ViewModels
{
    public class MoneyViewModel : BaseViewModel
    {
        public MoneyViewModel()
        {
            Title = "$Trackr";

            Balance = 0;
        }

        public decimal Balance { get; set; }

    }
}
