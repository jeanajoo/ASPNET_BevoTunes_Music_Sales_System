using System.ComponentModel.DataAnnotations;
using G6_BevoTunes.Controllers;
using Microsoft.Net.Http.Headers;

namespace G6_BevoTunes.Models
{
    public class ProductsViewModel
    {
        public List<Album>? Albums {get; set;}

        public List<Song>? Songs {get; set;}
    }

}
