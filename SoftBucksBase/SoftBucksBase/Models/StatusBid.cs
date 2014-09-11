using System;
using System.Collections.Generic;

namespace SoftBucksBase.Models
{
    public partial class StatusBid
    {
        public StatusBid()
        {
            this.Bids = new List<Bid>();
        }

        public int Id { get; set; }
        public string BidStatus { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
