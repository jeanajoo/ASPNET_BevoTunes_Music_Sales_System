using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public enum UserStatus { Active, Blocked, Deleted }

    public class AppUser : IdentityUser
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Address")]
        public String Address { get; set; }

        [Display(Name = "Zip Code")]
        public String ZipCode { get; set; }

        [Display(Name = "Status")]
        public UserStatus Status { get; set; }
        public List<Order> Orders { get; set; } = new List<Order> ();

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<CustCreditCard> CreditCards { get; set; } = new List<CustCreditCard>();

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
