using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G6_BevoTunes.Models
{
    public class Review
    {
        public Int32 ReviewID { get; set; }

        [Required]
        [Display(Name = "Review Description")]
        public String? Description { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(1, 5)]
        public Int32 Rating { get; set; }

        [Display(Name = "Status")]
        public ReviewStatus Status { get; set; }

        [Required]
        public AppUser Reviewer { get; set; }
        public String ReviewerID { get; set; }

        public AppUser? Approver { get; set; }

        public Song? Song { get; set; }

        public Album? Album { get; set; }

        public Artist? Artist { get; set; }
    }

    public enum ReviewStatus
    {
        Pending,
        Approve,
        Reject
    }
}
