using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace footballClubMass.Models
{
    public class PlayerContract : Contract
    {
        private float _salary;

        [Required]
        public float Salary
        {
            get => _salary;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Salary value can not be lower than 0");
                }
                _salary = value;
            }
        }

        private Player _player;

        public int playerId { get; set; }
        [ForeignKey("playerId")]
        public virtual Player player
        {
            get => _player;
            set
            {
                if (value == _player) return;
                if (value == null)
                {
                    throw new ArgumentNullException("Player value can not be null");
                }
                _player = value;
            }
        }

        public PlayerContract(DateTime endDate, float salary) : base(endDate)
        {
            this.Salary = salary;
        }

    }
}