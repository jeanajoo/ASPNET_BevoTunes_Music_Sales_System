using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G6_BevoTunes.Models
{
    public class Order
    {
        public Int32 OrderID { get; set; }

        [Display(Name = "Buyer:")]
        public AppUser Customer { get; set; }

        [Display(Name = "Using Card:")]
        public CustCreditCard Card { get; set; }

        [Display(Name = "Recipient")]
        public AppUser Recipient { get; set; }

        [Display(Name = "Order Details:")]
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [Display(Name = "Date of Order:")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        InCart,
        Ordered,
        Refunded
    }
}
