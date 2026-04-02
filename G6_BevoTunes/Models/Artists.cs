using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models.ViewModels
{
    public class Artists 
    {
        public int ArtistId { get; set; }

        public string? ArtistName { get; set; }

        public List<Genre>? Genre { get; set; }

    }
}