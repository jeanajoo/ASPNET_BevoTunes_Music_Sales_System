using G6_BevoTunes.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models.ViewModels
{
    public class Promotions
    {
        public int PromotionId { get; set; }

        public string? PromotionType { get; set; }

        public decimal DiscountPrice { get; set; }

        public bool PromotionActive { get; set; }

        public List<Song>? Songs { get; set; }

        public List<Album>? Albums { get; set; }

        public List<Artist>? Artists { get; set; }
    }

}