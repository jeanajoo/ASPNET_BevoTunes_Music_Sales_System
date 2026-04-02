using System.ComponentModel.DataAnnotations;
namespace G6_BevoTunes.Models;

public class Order
{
public Int32 OrderID {get; set;}
public AppUser Customer {get; set;}
public CustCreditCard Card {get; set;}
public AppUser? Friend {get; set;}
public List<OrderDetail> OrderDetails {get; set;}
public DateTime OrderDate {get; set;}
}