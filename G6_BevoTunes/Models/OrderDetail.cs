using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G6_BevoTunes.Models
{
    public class OrderDetail
    {
        public Int32 OrderDetailID { get; set; }

        [Display(Name = "Order Number")]
        public Order Order { get; set; }

        [Display(Name = "Album")]
        public Album? Album { get; set; }

        [Display(Name = "Song")]
        public Song? Song { get; set; }

        [Display(Name = "Artist")]
        public Artist? Artist { get; set; }

        [Display(Name = "Price")]
        public Decimal PurchasedPrice { get; set; }
    }
}
