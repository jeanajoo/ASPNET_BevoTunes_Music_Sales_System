using System.ComponentModel.DataAnnotations;
using Microsoft.Net.Http.Headers;

namespace G6_BevoTunes.Models
{
    public class CreateSongViewModel
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public decimal SongPrice { get; set; }
        public List<string> ArtistNames { get; set; } = new List<string>();
        public List<string> GenreNames { get; set; } = new List<string>();
        public List<string> AlbumNames { get; set; } = new List<string>();
    }

    public class CreateAlbumViewModel
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public Decimal AlbumPrice { get; set; }
        public string? AlbumCover { get; set; }
        public List<string> ArtistNames { get; set; } = new List<string>();
        public List<string> GenreNames { get; set; } = new List<string>();
        public List<CreateSongViewModel> Songs { get; set; } = new List<CreateSongViewModel>();
    }

    public class ProductsViewModel
    {
        public List<Album>? Albums {get; set;}

        public List<Song>? Songs {get; set;}
    }
}
