using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Display(Name = "Genre Name")]
        [Required]
        [StringLength(60, ErrorMessage = "Genre name cannot be longer than 60 characters.")]
        public string GenreName { get; set; }

        public List<Album>? Albums { get; set; }

        public List<Artist>? Artists { get; set; }

        public List<Song>? Songs { get; set; }

        public List<Artist>? Artists { get; set; }

        public List<Album>? Albums { get; set; }

        public List<Song>? Songs { get; set; }
    }
}
