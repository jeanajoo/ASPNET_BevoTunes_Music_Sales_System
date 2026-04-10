using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models;
public class SearchViewModel
{
    [Display(Name = "Name:")]
    public String SearchString {get; set;}
    
    [Display(Name = "Description:")]
    public String Description {get; set;}

    [Display(Name = "Genre:")]
    public Int32 Genre {get; set;}

    [Display(Name = "Price:")]
    [Range(0, Int32.MaxValue, ErrorMessage="Please Fill in a Valid Number")]
    public Decimal Price {get; set;}

    public PriceBound pb {get; set;}

    [Display(Name = "Released After:")]
    public DateTime? ReleasedAfter {get; set;}
}

/*
sian balls
why we need another view model to encapsulate the search results is because we are doing both songs and albums
*/
public class SearchResultsViewModel
{
    public List<Song> Songs {get; set;}
    
    public List<Album> Albums {get; set;}
}

public enum PriceBound { GreaterThan, LessThan }