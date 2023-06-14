using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace footballClubMass.Models
{
    public class SetPieceCoachTypeDb
    {
        [Key]
        public int id { get; set; }

        public SetPieceCoachType type { get; set; }
        [ForeignKey("SetPieceCoach")]
        public int setPieceCoachId { get; set; }
        public SetPieceCoach SetPieceCoach { get; set; }

        public SetPieceCoachTypeDb(SetPieceCoachType type)
        {
            this.type = type;
        }
    }
}
