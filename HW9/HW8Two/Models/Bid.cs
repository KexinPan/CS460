namespace HW8Two.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        public int BidID { get; set; }

        public int ItemID { get; set; }

        [Required]
        [StringLength(64)]
        public string BuyerName { get; set; }

        [Required]
        [StringLength(2000)]
        [RegularExpression(@"^\d+&")]
        public string Price { get; set; }

        public DateTime DateValue { get; set; } = DateTime.Now;

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
