using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftBucksBase.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int BidId { get; set; }

        [Required(ErrorMessage = "Pay required")]
        [Range(0, int.MaxValue)]
        public int Value { get; set; }

        [DataType(DataType.Date)]
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
    }
}
