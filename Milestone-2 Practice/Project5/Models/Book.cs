using System.ComponentModel.DataAnnotations;

namespace Project5.Models
{
    public class Book
    {
        [Key]
        public int BookID{get; set;}
        [Required]
        public string Title{get; set;}
        [Required]
        public string Author{get; set;}
        [Required]
        public string Genre{get; set;}
        [Required]
        [Range(0,10)]
        public int AvailableCopies{get; set;}

    }
}