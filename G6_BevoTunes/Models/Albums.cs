using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models.ViewModels
{
    public class Albums
    {
        public int AlbumId { get; set; }

        public string? AlbumName { get; set; }

        public string? AlbumPrice { get; set; }

        public string? AlbumCover { get; set; }

        public List<Artists>? Artists { get; set; }

        public List<Genre>? Genre { get; set; }  

        public List<Songs>? Songs { get; set; }

    }
}