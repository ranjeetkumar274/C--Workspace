using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
 
namespace dotnetapp.Models
{
    public class Library
    {
        [Key]
        public int LibraryId{get;set;}
        [Required(ErrorMessage ="Name is required.")]
        public string Name{get;set;}
        [Required(ErrorMessage ="Address is required.")]
        public string Address{get;set;}
        [Range(0,int.MaxValue,ErrorMessage ="MaximumCapacity must be greater than or equal to 0.")]
        public int MaximumCapacity{get;set;}
        [JsonIgnore]
        public ICollection<Book>? Books{get;set;}
    }
}
