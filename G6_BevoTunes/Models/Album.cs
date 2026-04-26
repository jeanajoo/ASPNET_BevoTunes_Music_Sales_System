using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Display(Name = "Album Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Album name cannot be longer than 100 characters.")]
        public string AlbumName { get; set; }

        [Display(Name = "Album Price")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AlbumPrice { get; set; }

        [Display(Name = "Album Cover URL")]
        [Required]
        [Url]
        public string? AlbumCover { get; set; }

        public Boolean IsActive { get; set; } = true;

        public List<Artist> Artists { get; set; } = new List<Artist>();

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Song> Songs { get; set; } = new List<Song>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public List<Promotion> Promotions { get; set; } = new List<Promotion>();

        [Display(Name = "Average Rating")]
        public Decimal AverageRating 
        {
            get
            {
                // Safety check just in case the collection wasn't initialized
                if (Reviews == null)
                {
                    return -1.0m;
                }
                var approvedReviews = Reviews.Where(r => r.Status == ReviewStatus.Approve);
                if (!approvedReviews.Any())
                {
                    return -1.0m;
                } 
                else
                {
                    // 3. Safely calculate the average
                    return (decimal)approvedReviews.Average(r => r.Rating);
                }
            }
        }
    }
}
