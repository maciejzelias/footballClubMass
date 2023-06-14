using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using footballClubMass.Data;

namespace footballClubMass.Models
{
    public class Player : Employer
    {
        // private static List<Player> playerList = new List<Player>();
        // public static List<Player> GetAllPlayer()
        // Ekstensja klasy została zapewniona przez EF - dbContext.Players.ToList();


        private int? _tshirtNumber;
        public int? TshirtNumber
        {
            get => _tshirtNumber;
            set
            {
                if (value < 0 || value > 99)
                {
                    throw new ArgumentException("tshirt number value has to be in range 0-99");
                }
                _tshirtNumber = value;
            }
        }
        public virtual ICollection<PlayerContract> PlayerContractList { get; set; }

        [ForeignKey("PlayerInfo")]
        public int PlayerInfoId { get; set; }

        public virtual PlayerInfo PlayerInfo { get; set; }

        public PlayerType playerType { get; set; }

        public string? Role
        {
            get; set;
        }

        public string? InjuryDescription
        {
            get; set;
        }

        private Player(string name, string surname, int birthdayYear, string PESEL, int countOfTitles) : base(name, surname, birthdayYear, PESEL, countOfTitles)
        {
            this.PlayerContractList = new List<PlayerContract>();
        }
        private Player(string name, string surname, int birthdayYear, string PESEL, int countOfTitles, int tshirtNumber) : base(name, surname, birthdayYear, PESEL, countOfTitles)
        {
            this.TshirtNumber = tshirtNumber;
            this.PlayerContractList = new List<PlayerContract>();
        }

        public static Player createPrimaryPlayer(string name, string surname, int birthdayYear, string PESEL, int countOfTitles, string role)
        {
            var player = new Player(name, surname, birthdayYear, PESEL, countOfTitles);
            player.playerType = PlayerType.Primary;
            player.Role = role;
            return player;
        }
        public static Player createPrimaryPlayer(string name, string surname, int birthdayYear, string PESEL, int countOfTitles, int tshirtNumber, string role)
        {
            var player = new Player(name, surname, birthdayYear, PESEL, countOfTitles, tshirtNumber);
            player.playerType = PlayerType.Primary;
            player.Role = role;
            return player;
        }

        public static Player createReservePlayer(string name, string surname, int birthdayYear, string PESEL, int countOfTitles, string InjuryDescription)
        {
            var player = new Player(name, surname, birthdayYear, PESEL, countOfTitles);
            player.playerType = PlayerType.Reserve;
            player.InjuryDescription = InjuryDescription;
            return player;
        }
        public static Player createReservePlayer(string name, string surname, int birthdayYear, string PESEL, int countOfTitles, int tshirtNumber, string InjuryDescription)
        {
            var player = new Player(name, surname, birthdayYear, PESEL, countOfTitles, tshirtNumber);
            player.playerType = PlayerType.Reserve;
            player.InjuryDescription = InjuryDescription;
            return player;
        }

        public void makeNormal(string role)
        {
            this.playerType = PlayerType.Primary;
            this.Role = role;
            this.InjuryDescription = null;
        }

        public void makeSubstitute(string injury)
        {
            this.playerType = PlayerType.Reserve;
            this.InjuryDescription = injury;
            this.Role = null;
        }

        //przeciazenie

        public float getSalary()
        {
            float value = 0.0f;
            foreach (PlayerContract contract in PlayerContractList)
            {
                value += contract.Salary;
            }
            return value;
        }

        public float getSalary(int incomeTax)
        {
            float value = 0.0f;
            foreach (PlayerContract contract in PlayerContractList)
            {
                value += contract.Salary;
            }
            return value - value * (incomeTax / 100.0f);
        }

        // przesloniecie
        public override string ToString()
        {
            return this.Name;
        }

    }

    public enum PlayerType
    {
        Primary, Reserve
    }
}