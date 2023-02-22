using System.ComponentModel.DataAnnotations;

//Creating a new table to connect using CategoryId
namespace Mission06_clhwang.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
