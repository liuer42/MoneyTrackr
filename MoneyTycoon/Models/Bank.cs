using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyTycoon.Models
{
    public class Bank
    {
        [PrimaryKey]
        public int Id { get; set; }
        public decimal Balance { get; set; }
        //public IEnumerable<Transaction> Transactions { get; set; }
    }
}
