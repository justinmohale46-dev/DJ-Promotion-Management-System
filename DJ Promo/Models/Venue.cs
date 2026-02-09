using System.ComponentModel.DataAnnotations;

namespace DJ_Promo.Models
{
    public class Venue
    {
        [Key]
        public int VenueID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Gig> Gigs { get; set; }
    }
}