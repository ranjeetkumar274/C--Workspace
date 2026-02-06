using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace dotnetapp.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage ="Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Author is required.")]
        public string Author { get; set; }
        [Required(ErrorMessage ="Category is required.")]
        public string Category { get; set; }
        [Required(ErrorMessage ="Price amount is required.")]
 
        [Range(0.01,double.MaxValue,ErrorMessage ="Price amount must be greater than 0.")]
        public decimal Price { get; set; }
         [Required(ErrorMessage ="Name is required.")]
        public int LibraryId{get;set;}
        [JsonIgnore]
        public Library? Library{get;set;}
 
    }
}
