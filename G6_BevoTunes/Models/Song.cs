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
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SongPrice { get; set; }

        public List<Album>? Albums { get; set; }

        public List<Artist>? Artists { get; set; }

        public List<Genre>? Genre { get; set; }

        public List<Promotion>? Promotions { get; set; }

        public List<OrderDetail>? OrderDetails { get; set; }    

        public List<Review>? Reviews { get; set; }
    }
}