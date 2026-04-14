using System.Collections.Generic;

namespace G6_BevoTunes.Models
{
    public class HomeViewModel
    {
        public List<Artist> FeaturedArtists { get; set; } = new List<Artist>();
        public List<Album> FeaturedAlbums { get; set; } = new List<Album>();
        public List<Song> FeaturedSongs { get; set; } = new List<Song>();
    }
}
