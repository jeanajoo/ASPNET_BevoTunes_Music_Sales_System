using G6_BevoTunes.Models;
using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models.ViewModels
{
    public class Songs
    {
        public int SongId { get; set; }

        public string? SongTitle { get; set; }

        public string? SongPrice { get; set; }

        public List<Albums>? Albums { get; set; }

        public List<Artists>? Artists { get; set; }

        public List<Genre>? Genre { get; set; }
    }
}