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

        public Boolean IsActive { get; set; } = true;

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Artist> Artists { get; set; } = new List<Artist>();

        public List<Song> Songs { get; set; } = new List<Song>();
    }
}
