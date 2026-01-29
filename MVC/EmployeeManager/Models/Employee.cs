using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Models{

    public class Employee{

    [Key]
    [Required]
    public int EmpId{get; set;}

    [Required]
    public string Name{get; set;} = "";
    }

}