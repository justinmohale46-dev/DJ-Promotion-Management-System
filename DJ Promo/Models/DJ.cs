using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DJ_Promo.Models
{
    public class DJ
    {

        [Key]
        public int DJID { get; set; }

      
        public string StageName { get; set; }

        public ICollection<Gig> Gigs { get; set; }
    }
}