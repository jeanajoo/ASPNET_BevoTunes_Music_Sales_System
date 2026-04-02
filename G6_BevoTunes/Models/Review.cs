using System.ComponentModel.DataAnnotations;
using G6_BevoTunes.Models.ViewModels;

namespace G6_BevoTunes.Models
{
    public class Review
    {
        public Int32 ReviewID { get; set; }

        [Required]
        [Display(Name = "Review Title")]
        public String Title { get; set; }

        [Required]
        [Display(Name = "Review Description")]
        public String? Description { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(1, 5)]
        public Int32 Rating { get; set; }

        [Display(Name = "Approved")]
        public Boolean Approved { get; set; }   

        // public string ReviewerID { get; set; }
        [Required]
        public AppUser Reviewer { get; set; }   

        // public string ApproverID { get; set; }
        [Required]
        public AppUser Approver { get; set; }   
        // public int? SongID { get; set; }   
        public Song? Song { get; set; }

        // public int? AlbumID { get; set; }   
        public Album? Album { get; set; }    

        // public int? ArtistID { get; set; }   
        public Artist? Artist { get; set; }

    }
}
