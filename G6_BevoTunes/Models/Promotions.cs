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

        public List<Songs>? Songs { get; set; }

        public List<Albums>? Albums { get; set; }

        public List<Artists>? Artists { get; set; }
    }

}