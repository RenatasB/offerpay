using System;
using System.Collections.Generic;

namespace offerpay.Models
{
    public partial class Offer
    {
        public int Id { get; set; }
        public double Payout { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string LogoLocation { get; set; }
        public string Link { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
