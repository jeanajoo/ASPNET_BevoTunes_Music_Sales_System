using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        [Display(Name = "Album Name")]
        [Required]
        [StringLength(100, ErrorMessage = "Album name cannot be longer than 100 characters.")]
        public string AlbumName { get; set; }

        [Display(Name = "Album Price")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal AlbumPrice { get; set; }

        [Display(Name = "Album Cover URL")]
        [Required]
        [Url]
        public string? AlbumCover { get; set; }

        public List<Artist> Artists { get; set; } = new List<Artist>();

        public List<Genre> Genres { get; set; } = new List<Genre>();

        public List<Song> Songs { get; set; } = new List<Song>();

        public List<Review> Reviews { get; set; } = new List<Review>();

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public List<Promotion> Promotions { get; set; } = new List<Promotion>();
    }
}
