using System.ComponentModel.DataAnnotations;

namespace Mission06_clhwang.Models
{
    //Creating the necessary responses and get/set methods for everything that is in the form
    public class ApplicationResponse
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
        [Required]
        //Creating another table that links with Category.cs and CategoryId
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
