using System.ComponentModel.DataAnnotations;
namespace G6_BevoTunes.Models;

public class CustCreditCard
{
    public Int32 CardID {get; set;}

    [StringLength(16, MinimumLength = 15, ErrorMessage = "Your card number must be between 15 and 16 digits.")]
    public String CardNumber {get; set;}
    public CardType CardType {get; set;}
    public AppUser User {get; set;}
}

public enum CardType
{
    Amex,
    Visa,
    MasterCard,
    Discover,
}