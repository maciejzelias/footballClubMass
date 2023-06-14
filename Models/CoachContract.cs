using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace footballClubMass.Models
{
    public class CoachContract : Contract
    {
        private int _clause;

        [Required]
        public int Clause
        {
            get => _clause;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Clause value can not be lower than 0");
                }
                _clause = value;
            }
        }

        private Coach _coach;

        public int coachId { get; set; }
        [ForeignKey("coachId")]
        public virtual Coach coach
        {
            get => _coach;
            set
            {
                if (value == _coach) return;
                if (value == null)
                {
                    throw new ArgumentNullException("Coach value can not be null");
                }
                _coach = value;
            }
        }

        public CoachContract(DateTime endDate, int clause) : base(endDate)
        {
            this.Clause = clause;
        }

    }
}