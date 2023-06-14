

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace footballClubMass.Models
{
    public class PlayerInfo
    {
        [Key, ForeignKey("Player")]
        public int PlayerId { get; set; }

        private string _nickname;
        public string nickname
        {
            get => _nickname;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Nickname value can not be null");
                }
                _nickname = value;
            }
        }

        public BetterFoot betterFoot { get; set; }

        public virtual ICollection<PreviousClub> prevClubs { get; set; }

        public virtual Player player { get; set; }
    }

    public enum BetterFoot
    {
        left, right
    }

}