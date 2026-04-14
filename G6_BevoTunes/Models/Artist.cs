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

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Song> Songs { get; set; } = new List<Song>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<Promotion> Promotions { get; set; } = new List<Promotion>();
    }
}
