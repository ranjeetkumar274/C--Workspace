using System.ComponentModel.DataAnnotations;

namespace Project4.Models
{
    
    public class Student
    {
        [Key]
        public int StudentID{get; set;}

        [Required]
        public string Name{get; set;} = "";

        [Required]
        public string Course{get; set;} = "";

        [Required]
        [Range(1,4)]
        public int Year{get; set;}

        [Required]
        [Range(0.0,4.0)]
        public double GPA{get; set;}
    }
}