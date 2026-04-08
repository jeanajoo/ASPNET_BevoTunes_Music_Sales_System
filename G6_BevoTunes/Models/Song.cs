using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Song
    {
        public int SongId { get; set; }

        [Display(Name = "Song Title")]
        public string? SongTitle { get; set; }

        [Display(Name = "Song Price")]
        public decimal SongPrice { get; set; }

        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Artist> Artists { get; set; } = new List<Artist>();

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Review>? Reviews { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }

        public List<Promotion>? Promotions { get; set; }
    }
}
