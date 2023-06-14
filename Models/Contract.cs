using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace footballClubMass.Models
{
    public abstract class Contract
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime endDate { get; set; }

        public Dictionary<int, Page> PagesDictionary
        {
            get
            {
                Dictionary<int, Page> pages = new Dictionary<int, Page>();
                foreach (var x in Pages)
                {
                    pages.Add(x.pageNumber, x);
                }
                return pages;
            }
        }

        public virtual ICollection<Page> Pages { get; set; }

        public Contract(DateTime endDate)
        {
            this.endDate = endDate;
            this.Pages = new List<Page>();
        }

    }
}