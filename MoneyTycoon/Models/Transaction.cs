using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyTycoon.Models
{
    public class Transaction
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public DateTime Date { get; set; }

        [Ignore]
        public string Display => $"{Description} - " + (Value > 0 ? "Deposit: " : "Expense: -") + String.Format("{0:C}", Value);
    }
}
