using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models.ViewModels
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string? AlbumName { get; set; }

        public decimal AlbumPrice { get; set; }

        public string? AlbumCover { get; set; }

        public List<Artist>? Artists { get; set; }

        public List<Genre>? Genre { get; set; }  

        public List<Song>? Songs { get; set; }

    }
}