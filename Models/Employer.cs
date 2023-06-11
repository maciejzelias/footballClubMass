using System.ComponentModel.DataAnnotations;

namespace footballClubMass.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public int BirthdayYear { get; set; }

        [Required]
        [MaxLength(11)]
        public string PESEL { get; set; }

        [Required]
        public int CountOfTitles { get; set; }

        [Required]
        public int Age
        {
            get => CalculateAge();
        }

        private int CalculateAge()
        {
            // Implement the logic to calculate the age based on the BirthdayYear
            int currentYear = DateTime.Now.Year;
            int age = currentYear - BirthdayYear;
            return age;
        }
    }
}