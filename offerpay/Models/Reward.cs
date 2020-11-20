using System;
using System.Collections.Generic;

namespace offerpay.Models
{
    public partial class Reward
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PictureLocation { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
