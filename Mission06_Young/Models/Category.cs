using System.ComponentModel.DataAnnotations;

namespace Mission06_Young.Models
{
    public class Category //Model for the movie category table in the DB
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
