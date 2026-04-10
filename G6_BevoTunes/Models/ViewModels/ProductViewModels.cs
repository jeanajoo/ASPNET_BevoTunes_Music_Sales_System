using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models.ViewModels
{
    public class SongViewModel
    {
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public decimal SongPrice { get; set; }
        public List<string> ArtistNames { get; set; } = new List<string>();
        public List<string> GenreNames { get; set; } = new List<string>();
        public List<string> AlbumNames { get; set; } = new List<string>();
        public int ReviewCount { get; set; }
        public double AverageRating { get; set; }
        public int PromotionCount { get; set; }
    }

    public class AlbumViewModel
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public Decimal AlbumPrice { get; set; }
        public string? AlbumCover { get; set; }
        public List<string> ArtistNames { get; set; } = new List<string>();
        public List<string> GenreNames { get; set; } = new List<string>();
        public List<SongViewModel> Songs { get; set; } = new List<SongViewModel>();
    }
}
