using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DJ_Promo.Models
{
    public class Gig
    {
        [Key]
        public int GigID { get; set; }
        [ForeignKey("DJ")]
        public int DJID { get; set; }
        [ForeignKey("Venue")]
        public int VenueID { get; set; }
        public DJ DJ { get; set; }
        public Venue Venue { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }
    }
}