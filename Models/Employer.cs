using System.ComponentModel.DataAnnotations;

namespace footballClubMass.Models
{
    public abstract class Employer
    {
        [Key]
        public int Id { get; set; }


        private string _name;

        [Required]
        public string Name
        {
            get => _name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name value can not be null or empty !");
                }
                _name = value;
            }
        }

        private string _surname;

        [Required]
        public string Surname
        {
            get => _surname;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("name value can not be null or empty !");
                }
                _surname = value;
            }
        }

        private int _birthdayYear;

        [Required]
        public int BirthdayYear
        {
            get => _birthdayYear;
            set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException("Birthday year value can not be lower than 0 or higher than actual year!");
                }
                _birthdayYear = value;
            }
        }

        private string _pesel;

        [Required]
        [MaxLength(11)]
        public string PESEL
        {
            get => _pesel;
            set
            {
                if (value.Length != 11 || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("PESEL value can not be null and has to be length of 11!");
                }
                _pesel = value;
            }
        }


        private int _countOfTitles;
        [Required]
        public int CountOfTitles
        {
            get => _countOfTitles;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Count of titles value can not be lower than 0 !");
                }
                _countOfTitles = value;
            }
        }
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

        public Employer(string name, string surname, int birthdayYear, string pesel, int countOfTitles)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthdayYear = birthdayYear;
            this.PESEL = pesel;
            this.CountOfTitles = countOfTitles;
        }
    }
}