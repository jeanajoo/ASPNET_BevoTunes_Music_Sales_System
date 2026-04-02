using G6_BevoTunes.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Promotion
    {
        public int PromotionId { get; set; }

        [Display(Name = "Promotion Type")]
        public string? PromotionType { get; set; }

        [Display(Name = "Discount Price")]
        public decimal DiscountPrice { get; set; }

        public bool PromotionActive { get; set; }

        public List<Song>? Songs { get; set; }

        public List<Album>? Albums { get; set; }

        public List<Artist>? Artists { get; set; }
    }

}