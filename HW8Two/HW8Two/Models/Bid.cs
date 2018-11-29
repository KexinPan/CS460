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
        //[RegularExpression(@"^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage ="Please Input Legal Numbers")]
        [RegularExpression(@"^\d+$",ErrorMessage ="Please Input Legal Price")]
        public string Price { get; set; }

        public DateTime DateValue { get; set; } = DateTime.Now;

        public virtual Item Item { get; set; }

        public virtual Buyer Buyer { get; set; }
    }
}
