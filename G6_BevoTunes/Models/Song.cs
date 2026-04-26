using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Display(Name = "Song Title")]
        [Required]
        [StringLength(200, ErrorMessage = "Song title cannot be longer than 100 characters.")]
        public string SongTitle { get; set; }

        [Display(Name = "Song Price")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SongPrice { get; set; }

        [Display(Name = "Song Image")]
        public string? SongImage { get; set; }

        public Boolean IsActive { get; set; } = true;

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Artist> Artists { get; set; } = new List<Artist>();

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Review> Reviews { get; set; } = new List<Review>();    

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public List<Promotion> Promotions { get; set; } = new List<Promotion>();

        [Display(Name = "Average Rating")]
        public Decimal AverageRating 
        {
            get
            {
                if (Reviews.Count == 0)
                {
                    return -1.0m;
                }
                return Decimal.Parse(Reviews.Where(r => r.Status == ReviewStatus.Approve).Average(r => r.Rating).ToString());;
            }
        
        }
    }
}