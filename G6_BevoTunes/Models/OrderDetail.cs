using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models;

public class OrderDetail
{
    public Int32 OrderDetailID {get; set;}

    [Display(Name="Order Number")]
    public Int32 Order {get; set;} 

    // analogous to product;
    [Display(Name="Album")]
    public Album? Album {get; set;}
    
    [Display(Name="Song")]
    public Song? Song {get; set;} 

    [Display(Name="Price")]
    public Decimal PurchasedPrice {get; set;}
}