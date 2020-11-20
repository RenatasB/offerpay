using System;
using System.Collections.Generic;

namespace offerpay.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double BalanceChange { get; set; }

        public virtual User User { get; set; }
    }
}
