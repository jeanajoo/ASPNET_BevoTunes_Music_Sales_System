using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public enum PromotionType
    {
        [Display(Name = "Featured Item")]
        FEATURED,

        [Display(Name = "Item Discount")]
        DISCOUNT
    }
    public class Promotion
    {
        public int PromotionId { get; set; }

        [Display(Name = "Promotion Type")]
        [Required]
        public PromotionType PromotionType { get; set; }

        [Display(Name = "Discount Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal DiscountPrice { get; set; }

        [Display(Name = "Promotion Active")]
        public bool PromotionActive { get; set; }

        public List<Song> Songs { get; set; } = new List<Song>();

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Artist> Artists { get; set; } = new List<Artist>();
    }
}
