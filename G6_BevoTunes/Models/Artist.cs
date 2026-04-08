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

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Album>? Albums { get; set; }

        public List<Song>? Songs { get; set; }

        public List<Review>? Reviews { get; set; }

        public List<Promotion>? Promotions { get; set; }
    }
}
