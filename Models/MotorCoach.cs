

namespace footballClubMass.Models
{
    public class MotorCoach : Coach
    {
        public DegreeEducationType degreeEducationType { get; set; }
        public MotorCoach(string name, string surname, int birthdayYear, string PESEL, int countOfTitles, double baseSalary, DegreeEducationType degreeEducationType)
    : base(name, surname, birthdayYear, PESEL, countOfTitles, baseSalary)
        {
            this.degreeEducationType = degreeEducationType;
        }
        public override double calculateSalary()
        {
            switch (degreeEducationType)
            {
                case DegreeEducationType.Doctor:
                    return baseSalary + baseSalary * 0.7;
                case DegreeEducationType.Master:
                    return baseSalary + baseSalary * 0.5;
                case DegreeEducationType.Bachelor:
                    return baseSalary + baseSalary * 0.2;
                default:
                    return baseSalary;

            }
        }
    }

    public enum DegreeEducationType
    {
        Bachelor,
        Master,
        Doctor
    }

}