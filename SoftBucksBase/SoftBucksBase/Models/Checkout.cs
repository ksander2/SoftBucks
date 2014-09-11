using System;
using System.Collections.Generic;

namespace SoftBucksBase.Models
{
    public partial class Checkout
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int AllCost { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> BidId { get; set; }
    }
}
