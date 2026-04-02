using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Display(Name = "Album Name")]
        public string? AlbumName { get; set; }

        [Display(Name = "Album Price")]
        public decimal AlbumPrice { get; set; }

        [Display(Name = "Album Cover URL")]
        public string? AlbumCover { get; set; }

        public List<Artist>? Artists { get; set; }

        public List<Genre>? Genre { get; set; }  

        public List<Song>? Songs { get; set; }

    }
}