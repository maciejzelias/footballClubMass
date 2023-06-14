using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace footballClubMass.Models
{

    public class PreviousClub
    {
        [Key]
        public int id { get; set; }

        public string clubName { get; set; }

        [ForeignKey("PlayerInfo")]
        public int PlayerInfoId { get; set; }

        public virtual PlayerInfo PlayerInfo { get; set; }
    }
}
