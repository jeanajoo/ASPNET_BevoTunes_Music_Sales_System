using G6_BevoTunes.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public enum PromotionType
    {
        [Display(Name = "Featured Item")]
        FeaturedItem,

        [Display(Name = "Item Discount")]
        ItemDiscount,
    }
    public class Promotion
    {
        public int PromotionId { get; set; }

        [Display(Name = "Promotion Type")]
        public PromotionType PromotionType { get; set; }

        [Display(Name = "Discount Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DiscountPrice { get; set; }

        [Display(Name = "Promotion Active")]
        public bool PromotionActive { get; set; }

        public List<Song>? Songs { get; set; }

        public List<Album>? Albums { get; set; }

        public List<Artist>? Artists { get; set; }
    }

}