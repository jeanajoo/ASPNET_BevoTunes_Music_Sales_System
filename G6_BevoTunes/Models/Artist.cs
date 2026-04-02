using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models.ViewModels
{
    public class Artist 
    {
        public int ArtistId { get; set; }

        [Display(Name = "Artist Name")]
        public string? ArtistName { get; set; }

        public List<Genre>? Genre { get; set; }

    }
}