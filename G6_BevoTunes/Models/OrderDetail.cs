namespace G6_BevoTunes.Models;

public class OrderDetail
{
    public Int32 OrderDetailID {get; set;}
    public Int32 Order {get; set;} 
    // analogous to product;
    public Int32 Album {get; set;}
    public Int32 Song {get; set;} 
    public Decimal PurchasedPrice {get; set;}
}