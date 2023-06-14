

namespace footballClubMass.Models
{
    public abstract class Coach : Employer
    {
        private double _baseSalary;
        public double baseSalary
        {
            get => _baseSalary;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Base salary value can not be lower than 0");
                }
                _baseSalary = value;
            }
        }

        public virtual ICollection<CoachContract> CoachContractList { get; set; }
        public Coach(string name, string surname, int birthdayYear, string pesel, int countOfTitles, double baseSalary) : base(name, surname, birthdayYear, pesel, countOfTitles)
        {
            this.baseSalary = baseSalary;
            this.CoachContractList = new List<CoachContract>();
        }

        public abstract double calculateSalary();

    }
}