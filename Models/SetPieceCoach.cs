

namespace footballClubMass.Models
{
    public class SetPieceCoach : Coach
    {

        private Boolean? _canTeachPositioning { get; set; }
        public Boolean? CanTeachPositioning
        {
            get => _canTeachPositioning; set
            {
                if (!types.Contains(SetPieceCoachType.FreeKick))
                {
                    throw new ArgumentException("You cant add canTeachPositioning property to SetPieceCoach that is not Free kick type !");
                }
                _canTeachPositioning = value;
            }
        }

        private Boolean? _canTeachPanemka { get; set; }
        public Boolean? CanTeachPanemka
        {
            get => _canTeachPanemka; set
            {
                if (!types.Contains(SetPieceCoachType.PenaltyKick))
                {
                    throw new ArgumentException("You cant add canTeachPanemka property to SetPieceCoach that is not penalty kick type !");
                }
                _canTeachPanemka = value;
            }
        }
        public int countOfSpecializatons
        {
            get
            {
                return this.types.Count;
            }
        }



        public HashSet<SetPieceCoachType> types
        {
            get
            {
                HashSet<SetPieceCoachType> mappedTypes = new HashSet<SetPieceCoachType>();
                foreach (var x in Types)
                {
                    mappedTypes.Add(x.type);
                }
                return mappedTypes;
            }
        }

        public virtual ICollection<SetPieceCoachTypeDb> Types { get; set; }


        public SetPieceCoach(string name, string surname, int birthdayYear, string PESEL, int countOfTitles, double baseSalary) : base(name, surname, birthdayYear, PESEL, countOfTitles, baseSalary)
        {
            Types = new List<SetPieceCoachTypeDb>();
        }

        public void makeFreeKickCoach(Boolean canTeachPositioning)
        {
            this.Types.Add(new SetPieceCoachTypeDb(SetPieceCoachType.FreeKick));
            this.CanTeachPositioning = canTeachPositioning;
        }
        public void removeFreeKickType()
        {
            this._canTeachPositioning = null;
            this.Types.Remove(Types.First(t => t.type == SetPieceCoachType.FreeKick));
        }
        public void makePenaltyKickCoach(Boolean canTeachPanemka)
        {
            this.Types.Add(new SetPieceCoachTypeDb(SetPieceCoachType.PenaltyKick));
            this.CanTeachPanemka = canTeachPanemka;
        }

        public void removePenaltyKickType()
        {
            this._canTeachPanemka = null;
            this.Types.Remove(Types.First(t => t.type == SetPieceCoachType.PenaltyKick));
        }

        public override double calculateSalary()
        {
            return baseSalary + 1000 * types.Count;
        }
    }

    public enum SetPieceCoachType
    {
        FreeKick,
        PenaltyKick,
    }

}