using System.ComponentModel.DataAnnotations;

namespace G6_BevoTunes.Models;
public class AlbumSearchViewModel
{
    [Display(Name = "Album Name:")]
    public String AlbumName {get; set;}

    [Display(Name = "Artist Name:")]
    public String ArtistName {get; set;}
    
    [Display(Name = "Genre:")]
    public Int32 Genre {get; set;}

    [Range(1.0, 5.0)]
    public Decimal Rating {get; set;}

    public RatingBound RatingBound {get; set;}

    [Display(Name = "Released After:")]
    public DateTime? ReleasedAfter {get; set;}
}

public class SongSearchViewModel
{
    [Display(Name = "Song Name:")]
    public String SongTitle {get; set;}

    [Display(Name = "Album Name:")]
    public String AlbumName {get; set;}

    [Display(Name = "Artist Name:")]
    public String ArtistName {get; set;}
    
    [Display(Name = "Genre:")]
    public Int32 Genre {get; set;}

    [Range(1.0, 5.0)]
    public Decimal Rating {get; set;}

    public RatingBound RatingBound {get; set;}

    [Display(Name = "Released After:")]
    public DateTime? ReleasedAfter {get; set;}
}

public class ArtistSearchViewModel
{
    [Display(Name = "Name:")]
    public String ArtistName {get; set;}
    
    [Display(Name = "Genre:")]
    public Int32 Genre {get; set;}

    [Range(1.0, 5.0)]
    public Decimal Rating {get; set;}

    public RatingBound RatingBound {get; set;}
}

public enum RatingBound { GreaterThan, LessThan }