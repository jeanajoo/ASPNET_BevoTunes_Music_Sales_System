using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G6_BevoTunes.Models
{
    public class Order
    {
        private Decimal TAX_RATE = 0.0825m;
        public Int32 OrderID { get; set; }

        [Display(Name = "Buyer:")]
        public AppUser Customer { get; set; }

        [Display(Name = "Using Card:")]
        public CustCreditCard? Card { get; set; }

        [Display(Name = "Recipient")]
        public AppUser Recipient { get; set; }

        [Display(Name = "Order Details:")]
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [Display(Name = "Date of Order:")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Order Status")]
        public OrderStatus OrderStatus { get; set; }

        public Decimal Subtotal { get { return OrderDetails.Sum(od => od.PurchasedPrice); } }
        [Display(Name = "Sales Tax")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SalesTax { get { return Subtotal * TAX_RATE; } }
        [Display(Name = "Order Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal OrderTotal { get { return Subtotal + SalesTax; } }
    }

    public enum OrderStatus
    {
        InCart,
        Ordered,
        Refunded
    }
}
