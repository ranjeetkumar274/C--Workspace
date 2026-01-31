

namespace Project3.Models
{
    public class Employee
    {

        // Key Id
        public int EmployeeId{get; set;}
        // Required
        public string Name{get; set;}

        // Reqyuired and Range should be between 10000-200000
        public double Salary{get; set;}
    }
}