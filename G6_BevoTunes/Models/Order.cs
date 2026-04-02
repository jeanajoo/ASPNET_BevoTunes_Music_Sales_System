using System.ComponentModel.DataAnnotations;
namespace G6_BevoTunes.Models;

public class Order
{
public Int32 OrderID {get; set;}

[Display(Name="Buyer:")]
public AppUser Customer {get; set;}

[Display(Name="Using Card:")]
public CustCreditCard Card {get; set;}

[Display(Name="For A Friend?")]
public AppUser? Friend {get; set;}

[Display(Name="Order Details:")]
public List<OrderDetail> OrderDetails {get; set;}

[Display(Name="Date of Order:")]
public DateTime OrderDate {get; set;}
}