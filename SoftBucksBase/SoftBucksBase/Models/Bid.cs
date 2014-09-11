using System;
using System.Collections.Generic;

namespace SoftBucksBase.Models
{
    public partial class Bid
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Cost { get; set; }
        public string Comment { get; set; }
        public System.DateTime Date { get; set; }
        public int StatusId { get; set; }
        public virtual StatusBid StatusBid { get; set; }
    }
}
