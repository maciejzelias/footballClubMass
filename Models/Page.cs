using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace footballClubMass.Models
{
    public class Page
    {
        [Key]
        public int id { get; set; }
        private string _content;

        [Required]
        public string Content
        {
            get => _content;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Value of content of page can not be null or empty");
                }
                _content = value;
            }
        }

        public int pageNumber { get; set; }

        private Contract _contract;
        public int contractId { get; set; }
        [ForeignKey("contractId")]
        public virtual Contract Contract
        {
            get => _contract;
            set
            {
                if (value == _contract) return;
                if (value == null)
                {
                    throw new ArgumentNullException("Contract value can not be null");
                }
                _contract = value;
            }
        }
    }
}