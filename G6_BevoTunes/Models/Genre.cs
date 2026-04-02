using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Genre
    {
        public int GenreId { get; set; }

        [Display(Name = "Genre Name")]
        public string? GenreName { get; set; }

    }
}