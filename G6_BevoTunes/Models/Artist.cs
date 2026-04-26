using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Display(Name = "Artist Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Artist name cannot be longer than 100 characters.")]
        public string ArtistName { get; set; }

        [Display(Name = "Artist Image")]
        public string? ArtistImage { get; set; }

        public Boolean IsActive { get; set; } = true;

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Song> Songs { get; set; } = new List<Song>();

        public List<Review> Reviews { get; set; } = new List<Review>();

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
