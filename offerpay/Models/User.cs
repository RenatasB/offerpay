using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace offerpay.Models
{
    public partial class User
    {
        public User()
        {
            Offer = new HashSet<Offer>();
            Reward = new HashSet<Reward>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public double Balance { get; set; }
        public string Name { get; set; }
        public string Last { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }

        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Salt { get; set; }
        public virtual ICollection<Offer> Offer { get; set; }
        public virtual ICollection<Reward> Reward { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
